using Link.IoT.Infrastructure.Messaging.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using Link.IoT.Device.MessageProcessors;
using Link.IoT.Device.Models;

namespace Link.IoT.Device
{
    internal sealed class CloudMessagesReceiver
    {
        private readonly DeviceClient _client;

        public CloudMessagesReceiver(string connectionString)
        {
            _client = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task Start()
        {
            while (true)
            {
                Message receivedMessage = await _client.ReceiveAsync(TimeSpan.FromSeconds(2));
                if (receivedMessage == null) continue;

                await Process(receivedMessage);

                await _client.CompleteAsync(receivedMessage);
            }
        }

        private async Task Process(Message message)
        {
            if (message.Properties.ContainsKey("Operation"))
            {
                if (Enum.TryParse(message.Properties["Operation"], out Operation oper))
                {
                    var payload = Encoding.ASCII.GetString(message.GetBytes());
                    switch (oper)
                    {
                        case Operation.Unavalable:
                            var finishProcessor = new FinishEventMessageProcessor();
                            var bookedMessageDto = JsonConvert.DeserializeObject<FinishEventMessage>(payload);
                            await finishProcessor.Process(bookedMessageDto);
                            break;

                        case Operation.Available:
                            var startProcessor = new StartEventMessageProcessor();
                            var startMessageDto = JsonConvert.DeserializeObject<StartEventMessage>(payload);
                            await startProcessor.Process(startMessageDto);
                            break;
                    }
                }
            }
        }
    }
}
