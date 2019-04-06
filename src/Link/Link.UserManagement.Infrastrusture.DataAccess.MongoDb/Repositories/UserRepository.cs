using Link.UserManagement.Domain.Model.Entities;
using Link.UserManagement.Domain.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("LinkDb");
            _users = database.GetCollection<User>("Users");
        }
        public async Task<List<User>> Get()
        {
            var events = await _users.FindAsync(user => true);

            return await events.ToListAsync();
        }

        public async Task<User> Get(UserId id)
        {
            var expert = await _users.FindAsync(e => e.Id == id);

            return await expert.SingleAsync();
        }

        public Task<User> Create(User ev)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserId id, User newUser)
        {
            _users.ReplaceOneAsync(user => user.Id == id, newUser);
        }

        public void Remove(UserId userId)
        {
            _users.DeleteOneAsync(user => user.Id == userId);
        }
    }
}
