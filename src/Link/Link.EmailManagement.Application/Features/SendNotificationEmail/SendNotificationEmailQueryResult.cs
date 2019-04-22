using Link.Common.Domain.Framework.Frameworks;

namespace Link.EmailManagement.Application.Features.SendNotificationEmail
{
    public sealed class SendNotificationEmailQueryResult : IQueryResult
    {
        public SendNotificationEmailQueryResult()
        {
            Success = true;
        }

        public SendNotificationEmailQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
