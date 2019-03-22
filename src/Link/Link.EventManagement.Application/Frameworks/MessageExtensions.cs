using System;
using System.Collections.Generic;
using System.Text;

namespace Link.EventManagement.Application.Frameworks
{
    public static class MessageExtensions
    {
        public static Message SerializeToMessage<T>(this T message) where T : IMessage
        {
            var outgoingMessage = new Message(message.MessageName);
            outgoingMessage.SetPayload(message);

            return outgoingMessage;
        }
    }
}
