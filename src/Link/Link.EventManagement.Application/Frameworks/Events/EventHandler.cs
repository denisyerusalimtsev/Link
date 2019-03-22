using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.EventManagement.Application.Frameworks.Events
{
    public abstract class EventHandler<T> : IEventHandler<T>
        where T : IDomainEvent
    {
        public abstract Task Handle(T @event);

        public Task Handle(IDomainEvent @event)
        {
            return Handle((T)@event);
        }
    }
}
