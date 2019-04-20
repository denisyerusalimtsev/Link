using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Domain.Services.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> Get();

        Task<Event> Get(EventId id);

        Task<Event> Create(Event ev);

        void Update(EventId id, Event ev);

        void Remove(EventId eventId);
    }
}
