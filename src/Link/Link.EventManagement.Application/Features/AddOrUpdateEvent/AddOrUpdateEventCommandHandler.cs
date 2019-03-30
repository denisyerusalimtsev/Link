using Link.EventManagement.Application.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.AddOrUpdateEvent
{
    public sealed class AddOrUpdateEventCommandHandler
        : CommandHandler<AddOrUpdateEventCommand, AddOrUpdateEventCommand.Reply>
    {
        private readonly IEventRepository _events;

        public AddOrUpdateEventCommandHandler(
            ICommandValidator<AddOrUpdateEventCommand, AddOrUpdateEventCommand.Reply> validator,
            IEventRepository events)
            : base(validator)
        {
            _events = events;
        }

        protected override async Task<AddOrUpdateEventCommand.Reply> Handle(AddOrUpdateEventCommand command)
        {
            var ev = new Event(
                id: command.Id == null
                    ? EventId.NewEventId
                    : command.Id,
                userId: command.UserId,
                name: command.Name,
                type: command.Type,
                status: command.Status,
                countOfNeededExperts: command.CountOfNeededExperts,
                experts: new List<Expert>()
            );

            Event newEvent = await _events.Create(ev);

            return new AddOrUpdateEventCommand.Reply(newEvent.Id);
        }
    }
}