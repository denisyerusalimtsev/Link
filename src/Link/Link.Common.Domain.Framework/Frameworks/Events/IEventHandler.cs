using System.Threading.Tasks;
using Link.Common.Domain.Framework.Interfaces;

namespace Link.Common.Domain.Framework.Frameworks.Events
{
    public interface IEventHandler
    {
        Task Handle(IDomainEvent @event);
    }

    public interface IEventHandler<in T> : IEventHandler
        where T : IDomainEvent
    {
        Task Handle(T @event);
    }
}
