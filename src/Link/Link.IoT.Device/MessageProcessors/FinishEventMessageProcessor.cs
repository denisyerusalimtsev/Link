using System.Threading.Tasks;
using Link.IoT.Device.Models;

namespace Link.IoT.Device.MessageProcessors
{
    public class FinishEventMessageProcessor : IMessageProcessor<FinishEventMessage>
    {
        public Task Process(FinishEventMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
