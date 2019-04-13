using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.GetEventById
{
    public sealed class GetEventByIdQueryRunner : QueryRunner<GetEventByIdQuery, GetEventByIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IExpertService _expertService;

        public GetEventByIdQueryRunner(IEventRepository eventRepository, IExpertService expertService)
        {
            _eventRepository = eventRepository;
            _expertService = expertService;
        }

        public override async Task<GetEventByIdQueryResult> Run(GetEventByIdQuery query)
        {
            try
            {
                var ev = await _eventRepository.Get(query.Id);
                return new GetEventByIdQueryResult(ev);
            }
            catch (Exception message)
            {
                return new GetEventByIdQueryResult(message.Message);
            }
        }
    }
}
