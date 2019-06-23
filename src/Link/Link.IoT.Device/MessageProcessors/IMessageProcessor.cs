using System.Threading.Tasks;
using Link.IoT.Device.Models;

namespace Link.IoT.Device.MessageProcessors
{
    internal interface IMessageProcessor<in TMessage>
        where TMessage : IMessage
    {
        Task Process(TMessage message);
    }
}
