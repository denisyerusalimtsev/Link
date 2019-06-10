using Link.Common.Domain.Framework.Frameworks;

namespace Link.EventManagement.Application.Features.SendFinishReport
{
    public sealed class SendFinishReportQueryResult : IQueryResult
    {
        public SendFinishReportQueryResult()
        {
            Success = true;
        }

        public SendFinishReportQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
