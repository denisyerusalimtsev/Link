using System.Collections.Generic;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.Common.Domain.Framework.Frameworks.Events
{
    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);

        Task Dispatch(IList<IDomainEvent> events);
    }
}
