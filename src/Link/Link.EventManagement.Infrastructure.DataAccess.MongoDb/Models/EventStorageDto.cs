using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models
{
    public class EventStorageDto
    {
        [BsonElement("id")]
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("user")]
        public UserStorageDto User { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("expertType")]
        public ExpertType ExpertType { get; set; }

        [BsonElement("status")]
        public ExpertStatus Status { get; set; }

        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [BsonElement("longitude")]
        public double Longitude { get; set; }

        [BsonElement("startTime")]
        public DateTime StartTime { get; set; }

        [BsonElement("endTime")]
        public DateTime? EndTime { get; set; }

        [BsonElement("countOfNeededExperts")]
        public int CountOfNeededExperts { get; set; }

        [BsonElement("expertIds")]
        public List<ExpertId> ExpertIds { get; set; }

        [BsonElement("experts")]
        public List<ExpertStorageDto> Experts { get; set; }

        public static EventStorageDto FromDomain(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentException("Event is null.");
            }

            if (ev.Experts == null || ev.ExpertIds == null)
                return new EventStorageDto
                {
                    Id = ev.Id == null
                        ? new ObjectId()
                        : new ObjectId(ev.Id.Id),
                    UserId = ev.UserId.Id,
                    Name = ev.Name,
                    ExpertType = ev.ExpertType,
                    Status = ev.Status,
                    Latitude = ev.Latitude,
                    Longitude = ev.Longitude,
                    StartTime = ev.StartTime,
                    EndTime = ev.EndTime,
                    CountOfNeededExperts = ev.CountOfNeededExperts,
                    ExpertIds = new List<ExpertId>(),
                    Experts = new List<ExpertStorageDto>()
                };

            var experts = new List<ExpertStorageDto>();
            foreach (var expert in ev.Experts)
            {
                experts.Add(ExpertStorageDto.FromDomain(expert));
            }

            return new EventStorageDto
            {
                Id = ev.Id == null
                    ? new ObjectId()
                    : new ObjectId(ev.Id.Id),
                UserId = ev.UserId.Id,
                Name = ev.Name,
                ExpertType = ev.ExpertType,
                Status = ev.Status,
                Latitude = ev.Latitude,
                Longitude = ev.Longitude,
                StartTime = ev.StartTime,
                EndTime = ev.EndTime,
                CountOfNeededExperts = ev.CountOfNeededExperts,
                ExpertIds = new List<ExpertId>(ev.ExpertIds),
                Experts = experts
            };
        }

        public Event ToDomain()
        {
            var experts = new List<Expert>();
            foreach (var expert in Experts)
            {
                experts.Add(ExpertStorageDto.ToDomain(expert));
            }

            return new Event(
                id: new EventId(Id.ToString()),
                userId: new UserId(UserId),
                name: Name,
                expertType: ExpertType,
                status: Status,
                latitude: Latitude,
                longitude: Longitude,
                startTime: StartTime,
                endTime: EndTime,
                countOfNeededExperts: CountOfNeededExperts,
                expertIds: ExpertIds,
                experts: experts);
        }
    }
}
