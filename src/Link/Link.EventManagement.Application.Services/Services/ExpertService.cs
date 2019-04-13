using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Services.Services
{
    public class ExpertService : IExpertService
    {
        private readonly string _expertManagementUrl;

        public ExpertService(IConfiguration config)
        {
            _expertManagementUrl = config.GetSection("ExpertManagementUrl").Value;
        }

        public async Task<List<Expert>> GetExperts(IEnumerable<ExpertId> expertsId)
        {
            var expertsUrl = $"{_expertManagementUrl}/experts";
            using (var httpClient = new HttpClient())
            {
                var experts = await httpClient.GetAsync(_expertManagementUrl).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Expert>>(experts);
            }
        }
    }
}
