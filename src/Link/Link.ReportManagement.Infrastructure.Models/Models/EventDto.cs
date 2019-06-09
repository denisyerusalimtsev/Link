using System;

namespace Link.ReportManagement.Infrastructure.Models.Models
{
    public class EventDto
    {
        public string Id { get; set; }

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
