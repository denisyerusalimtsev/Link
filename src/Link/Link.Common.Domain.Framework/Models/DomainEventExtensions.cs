using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.Common.Domain.Framework.Models
{
    public static class DomainEventExtensions
    {
        public static IReadOnlyList<IDomainEvent> Add(this IReadOnlyList<IDomainEvent> domainEvents, params IReadOnlyList<IDomainEvent>[] domainEventsBatch)
        {
            IList<IReadOnlyList<IDomainEvent>> notNullDomainevents = domainEventsBatch.Where(e => e != null).ToList();
            int size = domainEvents.Count + notNullDomainevents.Sum(e => e.Count);
            var allDomainEvents = new List<IDomainEvent>(size);
            allDomainEvents.AddRange(domainEvents);

            foreach (var events in notNullDomainevents.Where(e => e != null))
            {
                allDomainEvents.AddRange(events);
            }

            return allDomainEvents;
        }
    }
}
