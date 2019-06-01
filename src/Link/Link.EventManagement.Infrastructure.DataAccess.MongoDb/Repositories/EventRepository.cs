using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<EventStorageDto> _events;

        public EventRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("LinkDb");
            _events = database.GetCollection<EventStorageDto>("Events");
        }

        public async Task<List<Event>> Get()
        {
            List<EventStorageDto> events = await _events.Find(ev => true).ToListAsync();

            return events.Select(e => e.ToDomain()).ToList();
        }

        public async Task<Event> Get(EventId id)
        {
            IAsyncCursor<EventStorageDto> eventCursor = await _events.FindAsync(e => e.Id == ObjectId.Parse(id.Id));
            EventStorageDto dto = eventCursor.SingleOrDefault();

            return dto?.ToDomain();
        }

        public async Task<Event> Create(Event ev)
        {
            EventStorageDto dto = EventStorageDto.FromDomain(ev);
            await _events.InsertOneAsync(dto);

            return dto.ToDomain();
        }

        public async Task Assign(EventId eventId, ExpertId expertId)
        {
            Event ev = await Get(eventId);
            ev.Experts.Add(expertId);
        }

        public void Update(EventId id, Event ev)
        {
            EventStorageDto dto = EventStorageDto.FromDomain(ev);
            _events.ReplaceOneAsync(even => even.Id == ObjectId.Parse(id.Id), dto);
        }

        public void Remove(EventId eventId)
        {
            _events.DeleteOneAsync(ev => ev.Id == ObjectId.Parse(eventId.Id));
        }
    }
}
