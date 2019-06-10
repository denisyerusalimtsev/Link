using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Application.Features.AssignExpertToEvent;
using System.Collections.Generic;
using System.Linq;

namespace Link.EventManagement.Application.Features.FinishEvent
{
    public sealed class FinishEventCommandValidator
        : ICommandValidator<FinishEventCommand, FinishEventCommand.Reply>
    {
        public void Validate(FinishEventCommand command)
        {
            var validationResults = new List<ValidationError>();
            if (command.EventId == null)
            {
                validationResults.Add(new ValidationError("id", "EventId is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(AssignExpertToEventCommand).Name, validationResults);
            }
        }
    }
}
