using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class ReportService : IReportService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public ReportService(
            Configurations configurations, 
            ICommunicationChannel communicationChannel)
        {
            _configurations = configurations;
            _communicationChannel = communicationChannel;
        }

        public async Task<MemoryStream> GetReportAsync(ReportParameters parameters)
        {
            return await _communicationChannel
                .SynchronousPostRequest<ReportParameters, MemoryStream>(
                    _configurations.ExpertManagementUrl, parameters);
        }
    }
}
