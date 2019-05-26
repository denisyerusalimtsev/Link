using System;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventQueryRunner : 
        QueryRunner<AssignExpertToEventQuery, AssignExpertToEventQueryResult>
    {
        private readonly IEventRepository _events;
        private readonly IExpertService _expertService;

        public AssignExpertToEventQueryRunner(
            IEventRepository events,
            IExpertService expertService)
        {
            _events = events;
            _expertService = expertService;
        }

        public override async Task<AssignExpertToEventQueryResult> Run(AssignExpertToEventQuery query)
        {
            try
            {
                var existedEvent = await _events.Get(query.EventId);
                var experts = await _expertService.GetExperts(query.ExpertsId);

                await _expertService.SendNotificationsToExperts(experts, existedEvent);

                return new AssignExpertToEventQueryResult();
            }
            catch (Exception message)
            {
                return new AssignExpertToEventQueryResult(message.Message);
            }
        }
    }
}
