namespace Link.IoT.Infrastructure.Messaging.Models
{
    public class StartEventDto
    {
        public StartEventDto(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; set; }

        public Operation Operation { get; set; } = Operation.Unavalable;
    }
}
