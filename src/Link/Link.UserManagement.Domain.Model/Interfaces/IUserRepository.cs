using Link.UserManagement.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.UserManagement.Domain.Model.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Get();

        Task<User> Get(UserId id);

        Task<User> Create(User ev);

        void Update(UserId id, User user);

        void Remove(UserId userId);
    }
}
