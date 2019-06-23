using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Communication
{
    public interface ICommunicationChannel
    {
        Task<TResult> SynchronousPostRequest<TPayload, TResult>(string url, TPayload payload);

        Task SynchronousPostRequestAsync<TPayload>(string url, TPayload payload);

        Task SynchronousPostRequestAsync(string url);

        Task<TResult> SynchronousGetRequest<TResult>(string url);
    }
}
