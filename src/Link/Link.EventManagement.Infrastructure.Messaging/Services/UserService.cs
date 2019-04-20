using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class UserService : IUserService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public UserService(Configurations configurations, ICommunicationChannel communicationChannel)
        {
            _configurations = configurations;
            _communicationChannel = communicationChannel;
        }
        public async Task<User> GetUser(UserId userId)
        {
            return await _communicationChannel
                .SynchronousRequest<UserId, User>(
                    _configurations.UserManagementUrl, userId);
        }

        public async Task<List<User>> GetUsers(IEnumerable<UserId> usersId)
        {
            return await _communicationChannel
                    .SynchronousRequest<IEnumerable<UserId>, IEnumerable<User>>(
                        _configurations.UserManagementUrl, usersId)
                as List<User>;
        }
    }
}
