using Link.Common.Domain.Framework.Frameworks;

namespace Link.EmailManagement.Application.Features.SendInviteEmail
{
    public sealed class SendInviteEmailQueryResult : IQueryResult
    {
        public SendInviteEmailQueryResult()
        {
            Success = true;
        }

        public SendInviteEmailQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
