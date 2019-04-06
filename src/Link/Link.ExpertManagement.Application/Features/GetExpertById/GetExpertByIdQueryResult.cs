using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Entities;

namespace Link.ExpertManagement.Application.Features.GetExpertById
{
    public sealed class GetExpertByIdQueryResult : IQueryResult
    {
        public GetExpertByIdQueryResult(Expert expert)
        {
            Success = true;
            Expert = expert;
        }

        public GetExpertByIdQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public Expert Expert { get; }

        public string ErrorMessage { get; }
    }
}
