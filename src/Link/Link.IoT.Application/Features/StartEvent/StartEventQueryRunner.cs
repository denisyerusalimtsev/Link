using Link.Common.Domain.Framework.Frameworks;
using Link.IoT.Hub.Cloud.Azure;
using Link.IoT.Hub.Cloud.Azure.Interfaces;
using System.Threading.Tasks;

namespace Link.IoT.Application.Features.StartEvent
{
    public sealed class StartEventQueryRunner : QueryRunner<StartEventQuery, StartEventQueryResult>
    {
        private readonly IIoTHub _hub;

        public StartEventQueryRunner(IIoTHub hub)
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
