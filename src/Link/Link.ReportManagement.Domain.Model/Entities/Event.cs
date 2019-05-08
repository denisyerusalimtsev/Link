using System;
using Link.Common.Domain.Framework.Models;
using Link.ReportManagement.Domain.Model.Enums;
using System.Collections.Generic;

namespace Link.ReportManagement.Domain.Model.Entities
{
    public class Event : Entity<Event>
    {
        public Event(
            string id,
            UserId userId,
            string name,
            ExpertType expertType,
            ExpertStatus status,
            int countOfNeededExperts,
            List<ExpertId> experts, 
            double latitude,
            double longitude,
            DateTime startTime, 
            DateTime endTime)
        {
            Id = id;
            UserId = userId;
            Name = name;
            ExpertType = expertType;
            Status = status;
            Latitude = latitude;
            Longitude = longitude;
            StartTime = startTime;
            EndTime = endTime;
            CountOfNeededExperts = countOfNeededExperts;
            Experts = new HashSet<ExpertId>(experts);
        }

        public string Id { get; }

        public UserId UserId { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public int CountOfNeededExperts { get; }

        public HashSet<ExpertId> Experts { get; }
    }
}
