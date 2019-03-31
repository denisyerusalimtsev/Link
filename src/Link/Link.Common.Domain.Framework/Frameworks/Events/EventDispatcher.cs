using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.Common.Domain.Framework.Frameworks.Events
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IDictionary<Type, IList<IEventHandler>> _eventHandlers;

        public EventDispatcher(IDictionary<Type, IList<IEventHandler>> eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public async Task Dispatch(IDomainEvent @event)
        {
            IList<IEventHandler> handlers;
            if (_eventHandlers.TryGetValue(@event.GetType(), out handlers))
            {
                IEnumerable<Task> tasks = handlers.Select(h => h.Handle(@event));
                await Task.WhenAll(tasks);
            }
        }

        public async Task Dispatch(IList<IDomainEvent> events)
        {
            if (events.Any())
            {
                var tasks = events.Select(Dispatch);
                await Task.WhenAll(tasks);
            }
        }
    }
}
