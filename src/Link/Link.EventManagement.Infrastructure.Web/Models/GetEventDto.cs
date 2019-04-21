using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class GetEventDto
    {
        public List<EventInfo> Events { get; set; }
    }
}
