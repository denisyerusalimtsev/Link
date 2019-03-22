using System.Collections.Generic;
using System.Collections.ObjectModel;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.Common.Domain.Framework.Models
{
    public abstract class PersistentAggregateRoot<T, TState> : PersistentEntity<T, TState>
        where TState : new()
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected PersistentAggregateRoot(TState state)
            : base(state)
        {
        }

        public virtual IReadOnlyList<IDomainEvent> DomainEvents => new ReadOnlyCollection<IDomainEvent>(_domainEvents);


        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
