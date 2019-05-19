using System.Collections.Generic;
using Link.EventManagement.Infrastructure.Messaging.Models;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class GetEventDto
    {
        public List<EventInfo> Events { get; set; }
    }
}
