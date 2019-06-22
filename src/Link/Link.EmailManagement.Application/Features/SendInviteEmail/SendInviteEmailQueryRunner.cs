using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;
using Link.EmailManagement.Domain.Model.Enums;
using Link.EmailManagement.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
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
                var ev = new Event(
                    new EventId(query.Event.Id),
                    new UserId(query.Event.UserId),
                    query.Event.Name,
                    Enum.Parse<ExpertType>(query.Event.ExpertType),
                    Enum.Parse<ExpertStatus>(query.Event.Status),
                    query.Event.Latitude,
                    query.Event.Longitude,
                    query.Event.StartTime,
                    query.Event.EndTime,
                    query.Event.CountOfNeededExperts);

                var experts = new List<Expert>();
                query.Experts.ForEach(action: e =>
                {
                    experts.Add(new Expert(
                        e.Id,
                        e.FirstName,
                        e.LastName,
                        e.Type,
                        e.Status,
                        new ExpertContactInfo(
                            e.Email,
                            e.PhoneNumber,
                            e.LinkedInUrl)
                        ));
                });

                await Task.Run(() =>
                {
                    experts.ForEach(async expert =>
                    {
                        var mail = new Email(
                            emailTo: expert.ContactInfo.Email,
                            subject: _mailCreator.AddSubject(),
                            body: _mailCreator.AddBody(ev, expert));

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
