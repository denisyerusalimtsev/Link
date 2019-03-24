using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

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

        public List<Event> Get()
        {
            return _events.Find(ev => true).ToList();
        }

        public Event Get(EventId id)
        {
            return _events.Find<Event>(ev => ev.Id == id).FirstOrDefault();
        }

        public Event Create(Event book)
        {
            _events.InsertOne(book);
            return book;
        }

        public void Update(EventId id, Event ev)
        {
            _events.ReplaceOne(book => book.Id == id, ev);
        }

        public void Remove(EventId eventId)
        {
            _events.DeleteOne(ev => ev.Id == eventId);
        }
    }
}
