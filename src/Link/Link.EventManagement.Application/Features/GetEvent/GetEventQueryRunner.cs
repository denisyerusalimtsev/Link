using System;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Interfaces;

namespace Link.EventManagement.Application.Features.GetEvent
{
    public sealed class GetEventQueryRunner : QueryRunner<GetEventQuery, GetEventQueryResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventQueryRunner(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public override async Task<GetEventQueryResult> Run(GetEventQuery query)
        {
            try
            {
                var events = await _eventRepository.Get();
                return new GetEventQueryResult(events);
            }
            catch (Exception message)
            {
                return  new GetEventQueryResult(message.Message);
            }
        }
    }
}
