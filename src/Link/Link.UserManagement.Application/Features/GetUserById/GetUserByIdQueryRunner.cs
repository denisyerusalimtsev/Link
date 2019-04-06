using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.UserManagement.Application.Features.GetUserById
{
    public sealed class GetUserByIdQueryRunner : QueryRunner<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository _users;

        public GetUserByIdQueryRunner(IUserRepository users)
        {
            _users = users;
        }

        public override async Task<GetUserByIdQueryResult> Run(GetUserByIdQuery query)
        {
            try
            {
                var user = await _users.Get(query.Id);
                return new GetUserByIdQueryResult(user);
            }
            catch (Exception message)
            {
                return new GetUserByIdQueryResult(message.Message);
            }
        }
    }
}
