using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.EventManagement.Application.Features.GetEvent
{
    public sealed class GetEventQueryResult : IQueryResult
    {
        public GetEventQueryResult(List<EventInfo> events)
        {
            Success = true;
            Events = events;
        }

        public GetEventQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public List<EventInfo> Events { get; }

        public string ErrorMessage { get; }
    }
}
