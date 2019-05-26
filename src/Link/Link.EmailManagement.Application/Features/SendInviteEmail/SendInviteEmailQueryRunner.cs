using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;
using Link.EmailManagement.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.EmailManagement.Application.Features.SendInviteEmail
{
    public sealed class SendInviteEmailQueryRunner 
        : QueryRunner<SendInviteEmailQuery, SendInviteEmailQueryResult>
    {
        private readonly IMailBox _mailBox;
        private readonly IMailCreator _mailCreator;

        public SendInviteEmailQueryRunner(
            IMailBox mailBox,
            IMailCreator mailCreator)
        {
            _mailBox = mailBox;
            _mailCreator = mailCreator;
        }

        public override async Task<SendInviteEmailQueryResult> Run(SendInviteEmailQuery query)
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
                            body: _mailCreator.AddBody(query.Event, expert));

                        await _mailBox.Send(mail);
                    });
                });

                return new SendInviteEmailQueryResult();
            }
            catch (Exception message)
            {
                return new SendInviteEmailQueryResult(message.Message);
            }
        }
    }
}
