using System;
using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Interfaces;

namespace Link.ExpertManagement.Application.Features.GetExpert
{
    public sealed class GetExpertQueryRunner : QueryRunner<GetExpertQuery, GetExpertQueryResult>
    {
        private readonly IExpertRepository _expertRepository;

        public GetExpertQueryRunner(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }

        public override async Task<GetExpertQueryResult> Run(GetExpertQuery query)
        {
            try
            {
                var experts = await _expertRepository.Get();
                return new GetExpertQueryResult(experts);
            }
            catch (Exception message)
            {
                return new GetExpertQueryResult(message.Message);
            }
        }
    }
}
