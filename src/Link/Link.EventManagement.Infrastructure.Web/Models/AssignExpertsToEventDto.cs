using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class AssignExpertsToEventDto
    {
        public EventId EventId { get; set; }

        public List<ExpertId> Experts { get; set; }
    }
}
