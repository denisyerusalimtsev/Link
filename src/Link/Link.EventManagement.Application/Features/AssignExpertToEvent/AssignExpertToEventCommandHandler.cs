using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommandHandler
        : CommandHandler<AssignExpertToEventCommand, AssignExpertToEventCommand.Reply>
    {
        private readonly IEventRepository _events;
        private readonly IExpertService _expertService;

        public AssignExpertToEventCommandHandler(
            ICommandValidator<AssignExpertToEventCommand, 
            AssignExpertToEventCommand.Reply> validator, 
            IEventRepository events, IExpertService expertService) 
            : base(validator)
        {
            _events = events;
            _expertService = expertService;
        }

        protected override async Task<AssignExpertToEventCommand.Reply> Handle(AssignExpertToEventCommand command)
        {
            var existedEvent = await _events.Get(command.EventId);
            var experts = await _expertService.GetExperts(command.ExpertsId);

            var assignEventModel = new
            {
                Event = existedEvent,
                Experts = experts
            };

            await _expertService.SendNotificationsToExperts(experts, existedEvent);

            return new AssignExpertToEventCommand.Reply(command.EventId, existedEvent.Experts);
        }
    }
}
