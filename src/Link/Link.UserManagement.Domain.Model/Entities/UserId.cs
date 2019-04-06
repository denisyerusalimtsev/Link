using System;
using Link.Common.Domain.Framework.Models;

namespace Link.UserManagement.Domain.Model.Entities
{
    public sealed class UserId : ValueObject<UserId>
    {
        public static UserId NewEventId => new UserId(Guid.NewGuid().ToString());

        public UserId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Id);

        protected override bool EqualsCore(UserId other)
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
