using System;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Interfaces;

namespace Link.EventManagement.Application.Features.GetEvent
{
    public sealed class GetEventByIdQueryRunner : QueryRunner<GetEventByIdQuery, GetEventByIdQueryResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdQueryRunner(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
