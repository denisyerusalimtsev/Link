using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Infrastructure.Messaging.Models;

namespace Link.EventManagement.Application.Features.GetEvent
{
    public sealed class GetEventQueryRunner : QueryRunner<GetEventQuery, GetEventQueryResult>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IExpertService _expertService;
        private readonly IUserService _userService;

        public GetEventQueryRunner(
            IEventRepository eventRepository,
            IExpertService expertService, 
            IUserService userService)
        {
            _eventRepository = eventRepository;
            _expertService = expertService;
            _userService = userService;
        }

        public override async Task<GetEventQueryResult> Run(GetEventQuery query)
        {
            try
            {
                var events = await _eventRepository.Get();
                var eventInfo = new List<EventInfo>();
                foreach (var ev in events)
                {
                    var userDto = await _userService.GetUser(ev.UserId);
                    var experts = await _expertService.GetExperts(ev.Experts);
                    eventInfo.Add(new EventInfo(ev, userDto.User, experts));
                }

                return new GetEventQueryResult(eventInfo);
            }
            catch (Exception message)
            {
                return new GetEventQueryResult(message.Message);
            }
        }
    }
}
