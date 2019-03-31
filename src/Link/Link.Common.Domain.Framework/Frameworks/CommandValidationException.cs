using System;
using System.Collections.Generic;

namespace Link.Common.Domain.Framework.Frameworks
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
