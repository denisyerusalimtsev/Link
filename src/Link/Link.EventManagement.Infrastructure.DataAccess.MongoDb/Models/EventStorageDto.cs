using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models
{
    public class EventStorageDto
    {
        //TO Do Add getting experts from Link.ExpertManagement by using HTTP calls
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public ExpertType ExpertType { get; set; }

        public ExpertStatus Status { get; set; }

        public int CountOfNeededExperts { get; set; }

        public List<ExpertStorageDto> Experts { get; set; }

        public static EventStorageDto FromDomain(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentException("Event is null.");
            }

            return new EventStorageDto
            {
                Id = ev.Id.Id,
                UserId = ev.UserId.Id,
                Name = ev.Name,
                ExpertType = ev.ExpertType,
                Status = ev.Status,
                CountOfNeededExperts = ev.CountOfNeededExperts,
                Experts = new List<ExpertStorageDto>()
            };
        }

        // ToDomain

        public static Event ToDomain(EventStorageDto ev)
        {
            if (ev == null)
            {
                throw new ArgumentException("Event is null.");
            }

            return new Event(
                id: new EventId(ev.Id),
                userId: new UserId(ev.UserId),
                name: ev.Name,
                expertType: ev.ExpertType,
                status: ev.Status,
                countOfNeededExperts: ev.CountOfNeededExperts,
                experts: new List<ExpertId>());
        }
    }
}
