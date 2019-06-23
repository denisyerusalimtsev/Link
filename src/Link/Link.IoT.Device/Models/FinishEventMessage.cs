using Link.IoT.Infrastructure.Messaging.Models;

namespace Link.IoT.Device.Models
{
    public class FinishEventMessage : IMessage
    {
        public Operation Operation { get; set; }
    }
}
