using Link.EventManagement.Application.Frameworks;
using System.Collections.Generic;
using System.Linq;

namespace Link.EventManagement.Application.Features.AddOrUpdateEvent
{
    public sealed class AddOrUpdateEventCommandValidator 
        : ICommandValidator<AddOrUpdateEventCommand, AddOrUpdateEventCommand.Reply>
    {
        public void Validate(AddOrUpdateEventCommand command)
        {
            var validationResults = new List<ValidationError>();

            if (command.Id == null || !command.Id.IsValid)
            {
                validationResults.Add(new ValidationError("id", "Event id is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(AddOrUpdateEventCommand).Name, validationResults);
            }
        }
    }
}
