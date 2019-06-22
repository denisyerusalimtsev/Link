using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;
using Link.EmailManagement.Domain.Model.Enums;
using Link.EmailManagement.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.EmailManagement.Application.Features.SendNotificationEmail
{
    public sealed class SendNotificationEmailQueryRunner
        : QueryRunner<SendNotificationEmailQuery, SendNotificationEmailQueryResult>
    {
        private readonly IMailBox _mailBox;
        private readonly IMailCreator _mailCreator;
        private readonly IAzureBlobClient _azureBlobClient;

        public SendNotificationEmailQueryRunner(
            IMailBox mailBox,
            IMailCreator mailCreator,
            IAzureBlobClient azureBlobClient)
        {
            _mailBox = mailBox;
            _mailCreator = mailCreator;
            _azureBlobClient = azureBlobClient;
        }

        public override async Task<SendNotificationEmailQueryResult> Run(SendNotificationEmailQuery query)
        {
            var ev = new Event(new EventId(query.Event.Id),new UserId(query.Event.UserId), query.Event.Name, 
                Enum.Parse<ExpertType>(query.Event.ExpertType), Enum.Parse<ExpertStatus>(query.Event.Status),
                query.Event.Latitude, query.Event.Longitude, query.Event.StartTime, query.Event.EndTime,
                query.Event.CountOfNeededExperts);
            var user = new User(new UserId(query.User.Id), query.User.FirstName,
                query.User.LastName, query.User.PhoneNumber, query.User.Email );
            try
            {
                await Task.Run(async () =>
                {
                    var report = await _azureBlobClient.UploadFromBlob(query.FileName);
                    report.Position = 0;
                    Email mail = new Email(
                        emailTo: user.Email,
                        subject: _mailCreator.AddSubject(),
                        body: _mailCreator.AddBody(ev),
                        attachment: _mailCreator.AddAttachment(report));

                    await _mailBox.Send(mail);
                });

                return new SendNotificationEmailQueryResult();
            }
            catch (Exception message)
            {
                return new SendNotificationEmailQueryResult(message.Message);
            }
        }
    }
}
