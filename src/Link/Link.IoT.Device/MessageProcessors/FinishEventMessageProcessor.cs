using System;
using System.Threading.Tasks;
using Link.IoT.Device.Models;

namespace Link.IoT.Device.MessageProcessors
{
    public class FinishEventMessageProcessor : IMessageProcessor<FinishEventMessage>
    {
        public Task Process(FinishEventMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Event has finished, expert is free");

            return Task.CompletedTask;
        }
    }
}
