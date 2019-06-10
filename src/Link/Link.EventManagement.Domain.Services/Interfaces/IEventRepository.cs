using Link.EventManagement.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Domain.Services.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> Get();

        Task<Event> Get(EventId id);

        Task<Event> Create(Event ev);

        Task Assign(EventId eventId, ExpertId expertId);

        void Update(EventId id, Event ev);

        void Remove(EventId eventId);

        Task Finish(EventId eventId);
    }
}
