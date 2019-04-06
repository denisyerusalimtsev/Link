using Link.Common.Domain.Framework.Frameworks;
using System.Collections.Generic;
using System.Linq;

namespace Link.UserManagement.Application.Features.AddOrUpdateUser
{
    public sealed class AddOrUpdateUserCommandValidator 
        : ICommandValidator<AddOrUpdateUserCommand, AddOrUpdateUserCommand.Reply>
    {
        public void Validate(AddOrUpdateUserCommand command)
        {
            var validationResults = new List<ValidationError>();

            if (command.Id == null || !command.Id.IsValid)
            {
                validationResults.Add(new ValidationError("id", "User id is invalid"));
            }

            if (validationResults.Any())
            {
                throw new CommandValidationException(typeof(AddOrUpdateUserCommand).Name, validationResults);
            }
        }
    }
}
