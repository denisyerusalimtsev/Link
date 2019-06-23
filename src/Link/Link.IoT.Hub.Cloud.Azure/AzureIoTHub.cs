using Link.IoT.Hub.Cloud.Azure.Interfaces;
using Link.IoT.Infrastructure.Messaging.Models;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Link.IoT.Hub.Cloud.Azure
{
    public class AzureIoTHub : IIoTHub
    {
        private readonly ServiceClient _serviceClient;

        public AzureIoTHub(string connectionString)
        {
            _serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        public async Task StartProjectWithExpertAsync(string expertId)
        {
            var dto = new StartEventDto(expertId);
            var json = JsonConvert.SerializeObject(dto);

            var message = new Message(Encoding.ASCII.GetBytes(json));
            message.Properties.Add("Operation", dto.Operation.ToString());

            await _serviceClient.SendAsync("LinkNotifyDevice", message);
        }

        public async Task FinishProjectWithExpertAsync(string expertId)
        {
            var dto = new FinishEventDto(expertId);
            var json = JsonConvert.SerializeObject(dto);

            var message = new Message(Encoding.ASCII.GetBytes(json));
            message.Properties.Add("Operation", dto.Operation.ToString());

            await _serviceClient.SendAsync("LinkNotifyDevice", message);
        }
    }
}
