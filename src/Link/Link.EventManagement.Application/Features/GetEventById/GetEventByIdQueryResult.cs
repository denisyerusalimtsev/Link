using System.Collections.Generic;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.GetEventById
{
    public sealed class GetEventByIdQueryResult : IQueryResult
    {
        public GetEventByIdQueryResult(Event ev, List<Expert> experts, User user)
        {
            Success = true;
            Event = ev;
            Experts = experts;
            User = user;
        }

        public GetEventByIdQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public Event Event { get; }

        public List<Expert> Experts { get; }

        public User User { get; }

        public string ErrorMessage { get; }
    }
}
