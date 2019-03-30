using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = Link.EventManagement.Domain.Model.Enums.Type;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models
{
    public class EventStorageDto
    {
        public string Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public Type Type { get; set; }

        public Status Status { get; set; }

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
                Type = ev.Type,
                Status = ev.Status,
                CountOfNeededExperts = ev.CountOfNeededExperts,
                Experts = ev.Experts.Select(ExpertStorageDto.FromDomain).ToList()
            };
        }

        // ToDomain
    }
}
