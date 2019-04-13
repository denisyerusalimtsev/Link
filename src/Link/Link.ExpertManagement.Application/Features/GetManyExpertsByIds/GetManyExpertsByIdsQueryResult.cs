using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.ExpertManagement.Application.Features.GetManyExpertsByIds
{
    public sealed class GetManyExpertsByIdsQueryResult : IQueryResult
    {
        public GetManyExpertsByIdsQueryResult(List<Expert> experts)
        {
            Success = true;
            Experts = experts;
        }

        public GetManyExpertsByIdsQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public List<Expert> Experts { get; }

        public string ErrorMessage { get; }
    }
}
