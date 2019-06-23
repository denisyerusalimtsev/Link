using System;
using Link.IoT.Device.Models;
using System.Threading.Tasks;

namespace Link.IoT.Device.MessageProcessors
{
    public class StartEventMessageProcessor : IMessageProcessor<StartEventMessage>
    {
        public Task Process(StartEventMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Event has started, Expert is unavailable.");

            return Task.CompletedTask;
        }
    }
}
