using Link.Common.Domain.Framework.Frameworks;
using System.Collections.Generic;
using System.Linq;

namespace Link.EventManagement.Application.Features.DeleteEvent
{
    public sealed class DeleteEventValidator 
        : ICommandValidator<DeleteEventCommand, DeleteEventCommand.Reply>
    {
        public void Validate(DeleteEventCommand command)
        {
            var validationResults = new List<ValidationError>();

            if (command.Id == null || !command.Id.IsValid)
            {
                validationResults.Add(new ValidationError("id", "Event id is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(DeleteEventCommand).Name, validationResults);
            }
        }
    }
}
