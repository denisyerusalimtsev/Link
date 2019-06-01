using Link.Common.Domain.Framework.Frameworks;

namespace Link.EventManagement.Application.Features.InviteExpertToEvent
{
    public class InviteExpertToEventQueryResult
        : IQueryResult
    {
        public InviteExpertToEventQueryResult()
        {
            Success = true;
        }

        public InviteExpertToEventQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
