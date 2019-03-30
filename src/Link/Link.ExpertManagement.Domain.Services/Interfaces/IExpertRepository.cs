using System.Collections.Generic;
using Link.ExpertManagement.Domain.Model.Entities;

namespace Link.ExpertManagement.Domain.Services.Interfaces
{
    public interface IExpertRepository
    {
        List<Expert> Get();

        Expert Get(ExpertId id);

        Expert Create(Expert expert);

        void Update(ExpertId id, Expert expert);

        void Remove(ExpertId expertId);
    }
}
