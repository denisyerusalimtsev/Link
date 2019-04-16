using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Interfaces;
using Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Repositories
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly IMongoCollection<ExpertStorageDto> _experts;

        public ExpertRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DefaultConnection"));
            IMongoDatabase database = client.GetDatabase("LinkDb");
            _experts = database.GetCollection<ExpertStorageDto>("Experts");
        }

        public async Task<List<Expert>> Get()
        {
            List<ExpertStorageDto> experts = await _experts.Find(expert => true).ToListAsync();
            var converted = experts.Select(e => e.ToDomain()).ToList();
            return converted;
        }

        public async Task<Expert> Get(ExpertId id)
        {
            IAsyncCursor<ExpertStorageDto> expertCursor = await _experts.FindAsync(e => e.Id.ToString() == id.Id);

            ExpertStorageDto dto = expertCursor.SingleOrDefault();

            return dto?.ToDomain();
        }

        public List<Expert> Get(List<ExpertId> ids)
        {
            List<Expert> experts = new List<Expert>();
            ids.ForEach(async id => experts.Add(await Get(id)));

            return experts;
        }

        public async Task<Expert> Create(Expert expert)
        {
            ExpertStorageDto dto = ExpertStorageDto.FromDomain(expert);
            await _experts.InsertOneAsync(dto);
            return dto.ToDomain();
        }

        public void Update(ExpertId id, Expert expert)
        {
            ExpertStorageDto dto = ExpertStorageDto.FromDomain(expert);
            _experts.ReplaceOneAsync(exp => exp.Id.ToString() == id.Id, dto);
        }

        public void Remove(ExpertId expertId)
        {
            _experts.DeleteOneAsync(exp => exp.Id.ToString() == expertId.Id);
        }
    }
}
