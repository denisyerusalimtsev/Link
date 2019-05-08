using System;
using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class CreateOrUpdateEventDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public ExpertType ExpertType { get; set; }

        public ExpertStatus Status { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CountOfNeededExperts { get; set; }

        public List<ExpertId> Experts { get; set; }
    }
}
