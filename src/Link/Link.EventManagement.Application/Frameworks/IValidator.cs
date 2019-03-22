using System.Collections.Generic;

namespace Link.EventManagement.Application.Frameworks
{
    public interface IValidator<in T>
    {
        IEnumerable<IValidationResult> Validate(T subject);

        IEnumerable<IValidationResult> ValidateWithoutRequire(T subject);
    }
}
