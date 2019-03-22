using System.Collections.Generic;

namespace Link.EventManagement.Application.Frameworks
{
    public interface IValidationResult
    {
        string Field { get; }

        IEnumerable<string> Messages { get; }

        ErrorLevel ErrorLevel { get; }

    }
}
