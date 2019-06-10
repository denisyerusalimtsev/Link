using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommandHandler 
        : CommandHandler<AssignExpertToEventCommand, AssignExpertToEventCommand.Reply>
    {
        private readonly IEventRepository _events;

        public AssignExpertToEventCommandHandler(
            ICommandValidator<AssignExpertToEventCommand,
                AssignExpertToEventCommand.Reply> validator,
            IEventRepository events) : base(validator)
        {
            _events = events;
        }

        protected override async Task<AssignExpertToEventCommand.Reply> HandleAsync(AssignExpertToEventCommand command)
        {
            var eventId = new EventId(command.EventId);
            var expertId = new ExpertId(command.ExpertId);

            await _events.Assign(eventId, expertId);

            return new AssignExpertToEventCommand.Reply(command.EventId);
        }
    }
}
