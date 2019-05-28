using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Infrastructure.Models.Models;
using System.Collections.Generic;

namespace Link.EmailManagement.Application.Features.SendInviteEmail
{
    public sealed class SendInviteEmailQuery : IQuery<SendInviteEmailQueryResult>
    {
        public SendInviteEmailQuery(List<ExpertDto> experts, EventDto ev)
        {
            Experts = experts;
            Event = ev;
        }

        public List<ExpertDto> Experts { get; set; }

        public EventDto Event { get; set; }
    }
}
