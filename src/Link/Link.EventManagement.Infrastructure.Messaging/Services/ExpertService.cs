using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
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
            _communicationChannel = communicationChannel;
            _configurations = new Configurations(config);
        }

        public async Task<Expert> GetExpert(ExpertId expertId)
        {
            return await _communicationChannel
                .SynchronousRequest<ExpertId, Expert>(
                    _configurations.ExpertManagementUrl, expertId);
        }

        public async Task<List<Expert>> GetExperts(IEnumerable<ExpertId> expertsId)
        {
            return await _communicationChannel
                .SynchronousRequest<IEnumerable<ExpertId>, IEnumerable<Expert>>(
                        _configurations.ExpertManagementUrl, expertsId) 
                as List<Expert>;
        }
    }
}
