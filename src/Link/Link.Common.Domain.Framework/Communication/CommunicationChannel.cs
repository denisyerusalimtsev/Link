﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Communication
{
    public sealed class CommunicationChannel : ICommunicationChannel
    {
        public async Task<TResult> SynchronousPostRequest<TPayload, TResult>(string url, TPayload payload)
        {
            string json = JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(
                    new Uri(url), 
                    new StringContent(json, Encoding.UTF8, "application/json"));
                string responseContent = await response.Content.ReadAsStringAsync();
                TResult result = JsonConvert.DeserializeObject<TResult>(responseContent);

                return result;
            }
        }

        public async Task SynchronousPostRequestAsync<TPayload>(string url, TPayload payload)
        {
            string json = JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                await client.PostAsync(new Uri(url), new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }

        public async Task SynchronousPostRequestAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsync(new Uri(url), null);
            }
        }

        public async Task<TResult> SynchronousGetRequest<TResult>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(url));

                string responseContent = await response.Content.ReadAsStringAsync();
                TResult result = JsonConvert.DeserializeObject<TResult>(responseContent);

                return result;
            }
        }
    }
}