using System.Collections.Generic;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.EventManagement.Application.Features.GetEventById
{
    public sealed class GetEventByIdQueryResult : IQueryResult
    {
        public GetEventByIdQueryResult(Event ev, List<Expert> experts, UserStorageDto user)
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

        public UserStorageDto User { get; }

        public string ErrorMessage { get; }
    }
}
