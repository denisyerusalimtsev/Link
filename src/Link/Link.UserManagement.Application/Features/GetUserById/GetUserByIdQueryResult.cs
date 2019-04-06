using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;

namespace Link.UserManagement.Application.Features.GetUserById
{
    public sealed class GetUserByIdQueryResult : IQueryResult
    {
        public GetUserByIdQueryResult(User user)
        {
            Success = true;
            User = user;
        }

        public GetUserByIdQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public User User { get; }

        public string ErrorMessage { get; }
    }
}
