using Link.Common.Domain.Framework.Frameworks;
using Link.IoT.Hub.Cloud.Azure;
using Link.IoT.Hub.Cloud.Azure.Interfaces;
using System.Threading.Tasks;

namespace Link.IoT.Application.Features.StopEvent
{
    public sealed class StopEventQueryRunner : QueryRunner<StopEventQuery, StopEventQueryResult>
    {
        private readonly IIoTHub _hub;

        public StopEventQueryRunner(IIoTHub hub)
        {
            _hub = hub;
        }

        public override async Task<StopEventQueryResult> Run(StopEventQuery query)
        {
            await _hub.FinishProjectWithExpertAsync(query.ExpertId);

            return new StopEventQueryResult();
        }
    }
}
