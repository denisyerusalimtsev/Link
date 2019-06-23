using Link.Common.Domain.Framework.Frameworks;

namespace Link.IoT.Application.Features.StopEvent
{
    public sealed class StopEventQuery : IQuery<StopEventQueryResult>
    {
        public StopEventQuery(string expertId)
        {
            ExpertId = expertId;
        }

        public string ExpertId { get; }
    }
}
