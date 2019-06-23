using Link.Common.Domain.Framework.Frameworks;
using System;
using System.Threading.Tasks;
using Link.IoT.Hub.Cloud.Azure;

namespace Link.IoT.Application.Features.StartEvent
{
    public sealed class StartEventQueryRunner : QueryRunner<StartEventQuery, StartEventQueryResult>
    {
        private readonly AzureIoTHub _hub;

        public StartEventQueryRunner(AzureIoTHub hub)
        {
            _hub = hub;
        }

        public override async Task<StartEventQueryResult> Run(StartEventQuery query)
        {
            await _hub.StartProjectWithExpertAsync(query.ExpertId);

            return new StartEventQueryResult();
        }
    }
}
