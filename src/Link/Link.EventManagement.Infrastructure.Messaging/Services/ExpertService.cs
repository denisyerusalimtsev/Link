using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class ExpertService : IExpertService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public ExpertService(IConfiguration config, ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(config);
            _communicationChannel = communicationChannel;
        }

        public async Task<Expert> GetExpert(ExpertId expertId)
        {
            return await _communicationChannel
                .SynchronousPostRequest<ExpertId, Expert>(
                    _configurations.ExpertManagementUrl, expertId);
        }

        public async Task<GetExpertsDto> GetExperts(IEnumerable<ExpertId> expertsId)
        {
            var uri = string.Concat(_configurations.ExpertManagementUrl, "experts");
            return await _communicationChannel
                .SynchronousPostRequest<IEnumerable<ExpertId>, GetExpertsDto>(
                    uri, expertsId);
        }

        public async Task SendNotificationsToExperts(List<ExpertStorageDto> experts, EventTransfer ev)
        {
            var assignEventModel = new AssignEventModel(ev, experts);
            await _communicationChannel.SynchronousPostRequestAsync(
                _configurations.EmailManagementUrl, assignEventModel);
        }
    }
}
