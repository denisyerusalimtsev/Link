using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class IoTService : IIoTService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public IoTService(IConfiguration config, ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(config);
            _communicationChannel = communicationChannel;
        }

        public async Task StartEvent(string expertId)
        {
            await _communicationChannel
                .SynchronousPostRequestAsync(string.Concat(_configurations.IoTUrl, $"start/{expertId}"));
        }

        public async Task StopEvent(string expertId)
        {
            await _communicationChannel
                .SynchronousPostRequestAsync(string.Concat(_configurations.IoTUrl, $"stop/{expertId}"));
        }
    }
}
