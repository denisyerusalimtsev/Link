using Link.Common.Domain.Framework.Frameworks;
using System.Collections.Generic;
using System.Linq;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommandValidator 
        : ICommandValidator<AssignExpertToEventCommand, AssignExpertToEventCommand.Reply>
    {
        public void Validate(AssignExpertToEventCommand command)
        {
            var validationResults = new List<ValidationError>();
            if (command.EventId == null || command.ExpertId == null)
            {
                validationResults.Add(new ValidationError("id", "EventId or ExpertId is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(AssignExpertToEventCommand).Name, validationResults);
            }
        }
    }
}
