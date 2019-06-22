using Link.Common.Domain.Framework.Frameworks;
using Link.EmailManagement.Infrastructure.Models.Models;

namespace Link.EmailManagement.Application.Features.SendNotificationEmail
{
    public sealed class SendNotificationEmailQuery : IQuery<SendNotificationEmailQueryResult>
    {
        public SendNotificationEmailQuery(string fileName, UserDto user, EventDto ev)
        {
            FileName = fileName;
            User = user;
            Event = ev;
        }

        public string FileName { get; }

        public UserDto User { get; }

        public EventDto Event { get; }
    }
}
