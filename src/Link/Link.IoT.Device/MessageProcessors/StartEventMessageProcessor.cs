using Link.IoT.Device.Models;
using System.Threading.Tasks;

namespace Link.IoT.Device.MessageProcessors
{
    public class StartEventMessageProcessor : IMessageProcessor<StartEventMessage>
    {
        public Task Process(StartEventMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
