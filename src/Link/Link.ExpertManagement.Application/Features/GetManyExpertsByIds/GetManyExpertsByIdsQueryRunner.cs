using System;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Interfaces;

namespace Link.ExpertManagement.Application.Features.GetManyExpertsByIds
{
    public sealed class GetManyExpertsByIdsQueryRunner : QueryRunner<GetManyExpertsByIdsQuery, GetManyExpertsByIdsQueryResult>
    {
        private readonly IExpertRepository _experts;

        public GetManyExpertsByIdsQueryRunner(IExpertRepository experts)
        {
            _experts = experts;
        }

        public override async Task<GetManyExpertsByIdsQueryResult> Run(GetManyExpertsByIdsQuery query)
        {
            try
            {
                var experts = await Task.Run(() => _experts.Get(query.Ids));
                return new GetManyExpertsByIdsQueryResult(experts);
            }
            catch (Exception message)
            {
                return new GetManyExpertsByIdsQueryResult(message.Message);
            }
        }
    }
}
