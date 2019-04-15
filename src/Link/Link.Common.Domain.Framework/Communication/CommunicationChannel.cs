using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Communication
{
    public sealed class CommunicationChannel : ICommunicationChannel
    {
        public async Task<TResult> SynchronousRequest<TPayload, TResult>(string url, TPayload payload)
        {
            string json = JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(new Uri(url), new StringContent(json));

                string responseContent = await response.Content.ReadAsStringAsync();
                TResult result = JsonConvert.DeserializeObject<TResult>(responseContent);

                return result;
            }
        }
    }
}