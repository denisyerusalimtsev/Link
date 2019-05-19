using Link.UserManagement.Domain.Model.Entities;
using Link.UserManagement.Domain.Model.Interfaces;
using Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<UserStorageDto> _users;

        public UserRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("LinkDb");
            _users = database.GetCollection<UserStorageDto>("Users");
        }
        public async Task<List<User>> Get()
        {
            List<UserStorageDto> users = await _users.Find(user => true).ToListAsync();

            return users.Select(u => u.ToDomain()).ToList();
        }

        public async Task<User> Get(UserId id)
        {
            IAsyncCursor<UserStorageDto> userCursor = await _users.FindAsync(u => u.Id == ObjectId.Parse(id.Id));
            UserStorageDto dto = userCursor.SingleOrDefault();

            return dto?.ToDomain();
        }

        public async Task<User> Create(User user)
        {
            UserStorageDto dto = UserStorageDto.FromDomain(user);
            await _users.InsertOneAsync(dto);

            return dto?.ToDomain();
        }

        public void Update(UserId id, User newUser)
        {
            UserStorageDto dto = UserStorageDto.FromDomain(newUser);
            _users.ReplaceOneAsync(user => user.Id.ToString() == id.Id, dto);
        }

        public void Remove(UserId userId)
        {
            _users.DeleteOneAsync(user => user.Id.ToString() == userId.Id);
        }
    }
}
