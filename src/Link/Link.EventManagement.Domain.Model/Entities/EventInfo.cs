using System.Collections.Generic;
using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class EventInfo : Entity<EventInfo>
    {
        public EventInfo( 
            Event ev,
            User user,
            List<Expert> experts)
        {
            User = user;
            Name = ev.Name;
            ExpertType = ev.ExpertType;
            Status = ev.Status;
            Latitude = ev.Latitude;
            Longitude = ev.Longitude;
            CountOfNeededExperts = ev.CountOfNeededExperts;
            Experts = experts;
        }

        public User User { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public int CountOfNeededExperts { get; }

        public List<Expert> Experts { get; }
    }
}
