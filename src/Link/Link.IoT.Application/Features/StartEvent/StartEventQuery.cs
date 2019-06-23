using Link.Common.Domain.Framework.Frameworks;

namespace Link.IoT.Application.Features.StartEvent
{
    public sealed class StartEventQuery : IQuery<StartEventQueryResult>
    {
        public StartEventQuery(string expertId)
        {
            ExpertId = expertId;
        }

        public string ExpertId { get; }
    }
}
