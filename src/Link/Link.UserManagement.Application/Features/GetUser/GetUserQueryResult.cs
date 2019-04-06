using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.UserManagement.Application.Features.GetUser
{
    public sealed class GetUserQueryResult : IQueryResult
    {
        public GetUserQueryResult(List<User> users)
        {
            Success = true;
            Users = users;
        }

        public GetUserQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public List<User> Users { get; }

        public string ErrorMessage { get; }
    }
}
