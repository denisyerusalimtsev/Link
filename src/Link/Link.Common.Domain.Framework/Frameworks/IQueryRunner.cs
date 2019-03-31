using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Frameworks
{
    public interface IQueryRunner<T> where T : IQueryResult
    {
        Task<T> Run(IQuery<T> query);
    }
}
