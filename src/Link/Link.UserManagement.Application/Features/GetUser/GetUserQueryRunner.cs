using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Application.Features.GetEvent;
using System;
using System.Threading.Tasks;
using Link.UserManagement.Domain.Model.Interfaces;

namespace Link.UserManagement.Application.Features.GetUser
{
    public sealed class GetUserQueryRunner : QueryRunner<GetUserQuery, GetUserQueryResult>
    {
        private readonly IUserRepository _users;

        public GetUserQueryRunner(IUserRepository user)
        {
            _users = user;
        }

        public override async Task<GetUserQueryResult> Run(GetUserQuery query)
        {
            try
            {
                var users = await _users.Get();
                return new GetUserQueryResult(users);
            }
            catch (Exception message)
            {
                return  new GetUserQueryResult(message.Message);
            }
        }
    }
}
