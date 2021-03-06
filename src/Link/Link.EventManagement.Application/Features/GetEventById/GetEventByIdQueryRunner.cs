﻿using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;

namespace Link.EventManagement.Application.Features.GetEventById
{
    public sealed class GetEventByIdQueryRunner : QueryRunner<GetEventByIdQuery, GetEventByIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IExpertService _expertService;
        private readonly IUserService _userService;

        public GetEventByIdQueryRunner(
            IEventRepository eventRepository, 
            IExpertService expertService, 
            IUserService userService)
        {
            _eventRepository = eventRepository;
            _expertService = expertService;
            _userService = userService;
        }

        public override async Task<GetEventByIdQueryResult> Run(GetEventByIdQuery query)
        {
            try
            {
                var ev = await _eventRepository.Get(query.Id);
                var expertDto = await _expertService.GetExperts(ev.ExpertIds);
                var userDto = await _userService.GetUser(ev.UserId);
                return new GetEventByIdQueryResult(ev, expertDto.Experts, userDto.User);
            }
            catch (Exception message)
            {
                return new GetEventByIdQueryResult(message.Message);
            }
        }
    }
}
