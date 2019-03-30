using System.Collections.Generic;
using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Repositories
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly IMongoCollection<Expert> _events;

        public ExpertRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            var database = client.GetDatabase("LinkDb");
            _events = database.GetCollection<Expert>("Experts");
        }

        public List<Expert> Get()
        {
            return _events.Find(expert => true).ToList();
        }

        public Expert Get(ExpertId id)
        {
            return _events.Find<Expert>(expert => expert.Id == id).FirstOrDefault();
        }

        public Expert Create(Expert expert)
        {
            _events.InsertOne(expert);
            return expert;
        }

        public void Update(ExpertId id, Expert expert)
        {
            _events.ReplaceOne(exp => exp.Id == id, expert);
        }

        public void Remove(ExpertId expertId)
        {
            _events.DeleteOne(exp => exp.Id == expertId);
        }
    }
}
