using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using System;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class EventInfo : Entity<EventInfo>
    {
        public EventInfo( 
            Event ev,
            UserStorageDto user,
            List<ExpertStorageDto> experts)
        {
            Id = ev.Id.Id;
            User = user;
            Name = ev.Name;
            ExpertType = ev.ExpertType.ToString();
            Status = ev.Status.ToString();
            Latitude = ev.Latitude;
            Longitude = ev.Longitude;
            StartTime = ev.StartTime;
            EndTime = ev.EndTime;
            CountOfNeededExperts = ev.CountOfNeededExperts;
            Experts = experts;
        }

        public string Id { get; }

        public UserStorageDto User { get; }

        public string Name { get; }

        public string ExpertType { get; }

        public string Status { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public DateTime StartTime { get; }

        public DateTime? EndTime { get; }

        public int CountOfNeededExperts { get; }

        public List<ExpertStorageDto> Experts { get; }
    }
}
