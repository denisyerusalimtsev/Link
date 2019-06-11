using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class ReportService : IReportService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public ReportService(
            IConfiguration config,
            ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(config);
            _communicationChannel = communicationChannel;
        }

        public async Task<GenerateReportDto> GetReportAsync(ReportParameters parameters)
        {
            return await _communicationChannel
                .SynchronousPostRequest<ReportParameters, GenerateReportDto>(
                    _configurations.ReportManagementUrl, parameters);
        }
    }
}
