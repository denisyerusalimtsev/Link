using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;

namespace Link.UserManagement.Application.Features.GetUserById
{
    public sealed class GetUserByIdQuery : IQuery<GetUserByIdQueryResult>
    {
        public GetUserByIdQuery(UserId id)
        {
            Id = id;
        }

        public UserId Id { get; }
    }
}
