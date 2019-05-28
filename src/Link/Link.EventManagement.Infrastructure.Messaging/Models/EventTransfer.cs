using Link.EventManagement.Domain.Model.Entities;
using System;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class EventTransfer
    {
        public EventTransfer(Event ev)
        {
            UserId = ev.UserId.Id;
            Name = ev.Name;
            ExpertType = ev.ExpertType.ToString();
            Status = ev.Status.ToString();
            Latitude = ev.Latitude;
            Longitude = ev.Longitude;
            StartTime = ev.StartTime;
            EndTime = ev.EndTime;
            CountOfNeededExperts = ev.CountOfNeededExperts;
        }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string ExpertType { get; set; }

        public string Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int CountOfNeededExperts { get; set; }
    }
}
