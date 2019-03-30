using Link.Common.Domain.Framework.Models;

namespace Link.ExpertManagement.Domain.Model.Entities
{
    public class ExpertId : ValueObject<ExpertId>
    {
        public static ExpertId NewEventId => new ExpertId(0);

        public ExpertId(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public bool IsValid => Id > 0;

        protected override bool EqualsCore(ExpertId other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
