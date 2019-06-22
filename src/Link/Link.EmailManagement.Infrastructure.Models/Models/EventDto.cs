using Link.EmailManagement.Domain.Model.Entities;
using Link.EmailManagement.Domain.Model.Enums;
using System;

namespace Link.EmailManagement.Infrastructure.Models.Models
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

        public Event ToDomain()
        {
            return new Event(
                id: new EventId(Id),
                userId: new UserId(UserId),
                name: Name,
                expertType: Enum.Parse<ExpertType>(ExpertType),
                status: Enum.Parse<ExpertStatus>(Status),
                latitude: Latitude,
                longitude: Longitude,
                startTime: StartTime,
                endTime: EndTime,
                countOfNeededExperts: CountOfNeededExperts);
        }
    }
}
