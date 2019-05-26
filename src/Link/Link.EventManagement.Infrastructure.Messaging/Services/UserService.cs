using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class UserService : IUserService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public UserService(IConfiguration config, ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(config);
            _communicationChannel = communicationChannel;
        }
        public async Task<GetUserDto> GetUser(UserId userId)
        {
            return await _communicationChannel
                .SynchronousGetRequest<GetUserDto>(
                    $"{_configurations.UserManagementUrl}/{userId.Id}");
        }

        public async Task<List<User>> GetUsers(IEnumerable<UserId> usersId)
        {
            return await _communicationChannel
                    .SynchronousPostRequest<IEnumerable<UserId>, IEnumerable<User>>(
                        _configurations.UserManagementUrl, usersId)
                as List<User>;
        }
    }
}
