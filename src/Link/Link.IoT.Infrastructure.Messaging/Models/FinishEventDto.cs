namespace Link.IoT.Infrastructure.Messaging.Models
{
    public class FinishEventDto
    {
        public FinishEventDto(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; set; }

        public Operation Operation { get; set; } = Operation.Available;
    }
}
