using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.FinishEvent
{
    public sealed class FinishEventCommandHandler
        : CommandHandler<FinishEventCommand, FinishEventCommand.Reply>
    {
        private readonly IEventRepository _events;

        public FinishEventCommandHandler(
            ICommandValidator<FinishEventCommand, FinishEventCommand.Reply> validator,
            IEventRepository events) 
            : base(validator)
        {
            _events = events;
        }

        protected override async Task<FinishEventCommand.Reply> HandleAsync(FinishEventCommand command)
        {
            await _events.Finish(new EventId(command.EventId));

            return new FinishEventCommand.Reply(command.EventId);
        }
    }
}
