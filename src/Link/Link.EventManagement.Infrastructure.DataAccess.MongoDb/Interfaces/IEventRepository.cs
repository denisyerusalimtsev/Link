using System.Collections.Generic;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Interfaces
{
    public interface IEventRepository
    {
        List<Event> Get();

        Event Get(EventId id);

        Event Create(Event ev);

        void Update(EventId id, Event ev);

        void Remove(EventId eventId);
    }
}
