using Link.IoT.Infrastructure.Messaging.Models;

namespace Link.IoT.Device.Models
{
    public interface IMessage
    {
        Operation Operation { get; set; }
    }
}
