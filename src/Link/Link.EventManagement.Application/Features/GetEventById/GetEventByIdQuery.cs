using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.GetEventById
{
    public sealed class GetEventByIdQuery : IQuery<GetEventByIdQueryResult>
    {
        public GetEventByIdQuery(EventId id)
        {
            Id = id;
        }

        public EventId Id { get; }
    }
}
