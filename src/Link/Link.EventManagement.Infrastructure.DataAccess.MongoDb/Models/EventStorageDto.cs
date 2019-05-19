using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models
{
    public class EventStorageDto
    {
        //TO Do Add getting experts from Link.ExpertManagement by using HTTP calls
        [BsonElement("id")]
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

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
        public DateTime EndTime { get; set; }

        [BsonElement("countOfNeededExperts")]
        public int CountOfNeededExperts { get; set; }

        [BsonElement("experts")]
        public List<ExpertStorageDto> Experts { get; set; }

        public static EventStorageDto FromDomain(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentException("Event is null.");
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
                Experts = new List<ExpertStorageDto>()
            };
        }

        public Event ToDomain()
        {
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
                experts: new List<ExpertId>());
        }
    }
}
