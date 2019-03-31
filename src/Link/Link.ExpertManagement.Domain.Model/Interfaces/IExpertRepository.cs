using Link.ExpertManagement.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Domain.Model.Interfaces
{
    public interface IExpertRepository
    {
        Task<List<Expert>> Get();

        Task<Expert> Get(ExpertId id);

        Task<Expert> Create(Expert expert);

        void Update(ExpertId id, Expert expert);

        void Remove(ExpertId expertId);
    }
}
