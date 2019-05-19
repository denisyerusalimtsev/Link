using Link.Common.Domain.Framework.Frameworks;
using System.Collections.Generic;
using Link.EventManagement.Infrastructure.Messaging.Models;

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
