using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;

namespace Link.EmailManagement.Application.Features.SendFinishEventEmail
{
    public sealed class SendFinishEventEmailQueryRunner 
        : QueryRunner<SendFinishEventEmailQuery, SendFinishEventEmailQueryResult>
    {
        public override Task<SendFinishEventEmailQueryResult> Run(SendFinishEventEmailQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
