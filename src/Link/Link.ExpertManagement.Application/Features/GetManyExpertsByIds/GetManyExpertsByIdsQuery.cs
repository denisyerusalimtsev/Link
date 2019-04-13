using Link.ExpertManagement.Domain.Model.Entities;
using System.Collections.Generic;
using Link.Common.Domain.Framework.Frameworks;

namespace Link.ExpertManagement.Application.Features.GetManyExpertsByIds
{
    public sealed class GetManyExpertsByIdsQuery : IQuery<GetManyExpertsByIdsQueryResult>
    {
        public GetManyExpertsByIdsQuery(List<ExpertId> ids)
        {
            Ids = ids;
        }

        public List<ExpertId> Ids { get; }
    }
}
