using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Messaging.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Interfaces
{
    public interface IExpertService
    {
        Task<GetExpertsDto> GetExperts(IEnumerable<ExpertId> expertsId);

        Task SendNotificationsToExperts(List<ExpertStorageDto> experts, EventTransfer ev);
    }
}
