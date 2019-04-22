using System.Collections.Generic;
using System.IO;
using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Domain.Model.Entities;

namespace Link.EmailManagement.Application.Features.SendNotificationEmail
{
    public sealed class SendNotificationEmailQuery : IQuery<SendNotificationEmailQueryResult>
    {
        public SendNotificationEmailQuery(List<Expert> experts, Event ev, Stream attachments)
        {
            Experts = experts;
            Event = ev;
            Attachments = attachments;
        }

        public List<Expert> Experts { get; set; }

        public Event Event { get; set; }

        public Stream Attachments { get; set; }
    }
}
