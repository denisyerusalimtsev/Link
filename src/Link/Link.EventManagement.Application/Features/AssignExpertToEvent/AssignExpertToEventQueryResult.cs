using Link.Common.Domain.Framework.Frameworks;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public class AssignExpertToEventQueryResult
        : IQueryResult
    {
        public AssignExpertToEventQueryResult()
        {
            Success = true;
        }

        public AssignExpertToEventQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
