using Link.IoT.Device.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Link.IoT.Device
{
    public class CloudMessageSender
    {
        private readonly DeviceClient _client;

        public CloudMessageSender(string connectionString)
        {
            _client = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task Start(string deviceId)
        {
            var telemetry = new Telemetry(deviceId);

            while (true)
            {
                var json = JsonConvert.SerializeObject(telemetry);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(json);
                var message = new Message(Encoding.ASCII.GetBytes(json));
                await _client.SendEventAsync(message);

                telemetry.ChangeState();
                await Task.Delay(5000);
            }
        }
    }
}
