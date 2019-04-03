using System.Collections.Generic;
using System.Linq;
using Link.Common.Domain.Framework.Frameworks;

namespace Link.ExpertManagement.Application.Features.AddOrUpdateExpert
{
    public sealed class AddOrUpdateExpertCommandValidator 
        : ICommandValidator<AddOrUpdateExpertCommand, AddOrUpdateExpertCommand.Reply>
    {
        public void Validate(AddOrUpdateExpertCommand command)
        {
            var validationResults = new List<ValidationError>();

            if (command.Id == null || !command.Id.IsValid)
            {
                validationResults.Add(new ValidationError("id", "Event id is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(AddOrUpdateExpertCommand).Name, validationResults);
            }
        }
    }
}
