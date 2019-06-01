using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using System;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.InviteExpertToEvent
{
    public sealed class InviteExpertToEventQueryRunner : 
        QueryRunner<InviteExpertToEventQuery, InviteExpertToEventQueryResult>
    {
        private readonly IEventRepository _events;
        private readonly IExpertService _expertService;

        public InviteExpertToEventQueryRunner(
            IEventRepository events,
            IExpertService expertService)
        {
            _events = events;
            _expertService = expertService;
        }

        public override async Task<InviteExpertToEventQueryResult> Run(InviteExpertToEventQuery query)
        {
            try
            {
                var existedEvent = await _events.Get(query.EventId);
                var eventDto = new EventTransfer(existedEvent);
                var experts = await _expertService.GetExperts(query.ExpertsId);

                await _expertService.SendNotificationsToExperts(experts.Experts, eventDto);

                return new InviteExpertToEventQueryResult();
            }
            catch (Exception message)
            {
                return new InviteExpertToEventQueryResult(message.Message);
            }
        }
    }
}
