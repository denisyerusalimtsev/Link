using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.EmailManagement.Application.Features.SendInviteEmail
{
    public sealed class SendInviteEmailQuery : IQuery<SendInviteEmailQueryResult>
    {
        public SendInviteEmailQuery(List<Expert> experts, Event ev)
        {
            Experts = experts;
            Event = ev;
        }

        public List<Expert> Experts { get; set; }

        public Event Event { get; set; }
    }
}
