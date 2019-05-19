using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Communication
{
    public interface ICommunicationChannel
    {
        Task<TResult> SynchronousRequest<TPayload, TResult>(string url, TPayload payload);

        Task<TResult> SynchronousGetRequest<TResult>(string url);
    }
}
