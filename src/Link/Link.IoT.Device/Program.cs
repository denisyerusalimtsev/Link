using System;
using System.Threading.Tasks;

namespace Link.IoT.Device
{
    class Program
    {
        private const string ConnectionString = "HostName=LinkIoTHub.azure-devices.net;DeviceId=LinkNotifyDevice;SharedAccessKey=aZvWjbypD3KWBbJEXNq5XcPx7/FN8svdBMlOfa7C7/I=";
        private const string DeviceId = "LinkNotifyDevice";

        static void Main(string[] args)
        {
            var receiver = new CloudMessagesReceiver(ConnectionString);
            var sender = new CloudMessageSender(ConnectionString);

            var receiveMessages = Task.Run(async () => await receiver.Start());
            var sendTelemetry = Task.Run(async () => await sender.Start(DeviceId));

            Task.WhenAll(receiveMessages, sendTelemetry).GetAwaiter().GetResult();

            Console.WriteLine("Application STOP.");
        }
    }
}
