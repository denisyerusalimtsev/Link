using System.Threading.Tasks;

namespace Link.EventManagement.Application.Frameworks
{
    public interface IQueryRunner<T> where T : IQueryResult
    {
        Task<T> Run(IQuery<T> query);
    }
}
