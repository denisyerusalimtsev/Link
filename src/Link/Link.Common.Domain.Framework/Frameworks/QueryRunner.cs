using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Frameworks
{
    public abstract class QueryRunner<TQ, T> : IQueryRunner<T>
        where TQ : class, IQuery<T>
        where T : IQueryResult
    {
        public abstract Task<T> Run(TQ query);

        public Task<T> Run(IQuery<T> query)
        {
            return Run(query as TQ);
        }
    }
}
