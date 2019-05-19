using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.Messaging.Models;

namespace Link.EventManagement.Infrastructure.Messaging.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDto> GetUser(UserId userId);

        Task<List<User>> GetUsers(IEnumerable<UserId> usersId);
    }
}
