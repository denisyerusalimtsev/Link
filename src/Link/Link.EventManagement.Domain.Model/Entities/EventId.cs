using Link.Common.Domain.Framework.Models;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class EventId : ValueObject<EventId>
    {
        public static EventId NewEventId => new EventId(null);

        public EventId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Id);

        protected override bool EqualsCore(EventId other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
