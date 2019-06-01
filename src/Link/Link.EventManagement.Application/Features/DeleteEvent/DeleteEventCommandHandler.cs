using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;

namespace Link.EventManagement.Application.Features.DeleteEvent
{
    public sealed class DeleteEventCommandHandler
        : CommandHandler<DeleteEventCommand, DeleteEventCommand.Reply>
    {
        private readonly IEventRepository _events;

        public DeleteEventCommandHandler(
            ICommandValidator<DeleteEventCommand, DeleteEventCommand.Reply> validator,
            IEventRepository events) : base(validator)
        {
            _events = events;
        }

        protected override Task<DeleteEventCommand.Reply> HandleAsync(DeleteEventCommand command)
        {
            _events.Remove(command.Id);

            return Task.FromResult(new DeleteEventCommand.Reply(command.Id));
        }
    }
}
