using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;
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

        public SendNotificationEmailQueryRunner(
            IMailBox mailBox,
            IMailCreator mailCreator)
        {
            _mailBox = mailBox;
            _mailCreator = mailCreator;
        }

        public override async Task<SendNotificationEmailQueryResult> Run(SendNotificationEmailQuery query)
        {
            try
            {
                await Task.Run(() =>
                {
                    query.Experts.ForEach(async expert =>
                    {
                        var mail = new Email(
                            emailTo: expert.ContactInfo.Email,
                            subject: _mailCreator.AddSubject(),
                            body: _mailCreator.AddBody(query.Event, expert),
                            attachment: _mailCreator.AddAttachment(query.Attachments));

                        await _mailBox.Send(mail);
                    });
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
