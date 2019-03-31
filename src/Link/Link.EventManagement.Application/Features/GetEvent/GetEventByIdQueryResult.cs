using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.GetEvent
{
    public sealed class GetEventByIdQueryResult : IQueryResult
    {
        public GetEventByIdQueryResult(Event ev)
        {
            Success = true;
            Event = ev;
        }

        public GetEventByIdQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public Event Event { get; }

        public string ErrorMessage { get; }
    }
}
