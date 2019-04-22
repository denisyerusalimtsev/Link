using Link.Common.Domain.Framework.Models;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public class UserId : ValueObject<EventId>
    {
        public static EventId NewUserId => new EventId(string.Empty);

        public UserId(string id)
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
    }
}
