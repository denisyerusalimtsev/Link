using System;
using System.Collections.Generic;

namespace Link.EventManagement.Application.Frameworks
{
    public sealed class CommandValidationException : Exception
    {
        public CommandValidationException(string componentName, IReadOnlyCollection<ValidationError> errors)
        {
            ComponentName = componentName;
            Errors = errors;
        }

        public string ComponentName { get; }

        public IReadOnlyCollection<ValidationError> Errors { get; }
    }
}
