using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class AssignEventModel
    {
        public AssignEventModel(Event ev, List<Expert> experts)
        {
            Event = ev;
            Experts = experts;
        }

        public Event Event { get; set; }

        public List<Expert> Experts { get; set; }
    }
}
