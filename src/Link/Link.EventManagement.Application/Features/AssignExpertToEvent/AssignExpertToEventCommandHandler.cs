using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommandHandler 
        : CommandHandler<AssignExpertToEventCommand, AssignExpertToEventCommand.Reply>
    {
        private readonly IEventRepository _events;
        private readonly IIoTService _ioTService;

        public AssignExpertToEventCommandHandler(
            ICommandValidator<AssignExpertToEventCommand,
                AssignExpertToEventCommand.Reply> validator,
            IEventRepository events, IIoTService ioTService) : base(validator)
        {
            _events = events;
            _ioTService = ioTService;
        }

        protected override async Task<AssignExpertToEventCommand.Reply> HandleAsync(AssignExpertToEventCommand command)
        {
            var eventId = new EventId(command.EventId);
            var expertId = new ExpertId(command.ExpertId);

            await _events.Assign(eventId, expertId);
            await _ioTService.StartEvent(expertId.Id);

            return new AssignExpertToEventCommand.Reply(command.EventId);
        }
    }
}
