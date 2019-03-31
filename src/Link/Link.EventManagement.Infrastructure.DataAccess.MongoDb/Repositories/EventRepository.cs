using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<Event> _events;

        public EventRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("LinkDb");
            _events = database.GetCollection<Event>("Events");
        }

        public async Task<List<Event>> Get()
        {
            var events = await _events.FindAsync(ev => true);
            return await events.ToListAsync();
        }

        public async Task<Event> Get(EventId id)
        {
            var ev = await _events.FindAsync(e => e.Id == id);
            return await ev.SingleAsync();
        }

        public async Task<Event> Create(Event ev)
        {
            await _events.InsertOneAsync(ev);
            return ev;
        }

        public void Update(EventId id, Event ev)
        {
            _events.ReplaceOneAsync(even => even.Id == id, ev);
        }

        public void Remove(EventId eventId)
        {
            _events.DeleteOneAsync(ev => ev.Id == eventId);
        }
    }
}
