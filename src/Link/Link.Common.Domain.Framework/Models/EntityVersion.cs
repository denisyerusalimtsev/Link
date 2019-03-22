using System;
using System.Linq;

namespace Link.Common.Domain.Framework.Models
{
    public class EntityVersion : ValueObject<EntityVersion>
    {
        public EntityVersion(byte[] version) : this(FromBytes(version)) { }

        public EntityVersion(ulong version)
        {
            Version = version;
        }

        public ulong Version { get; }

        public static EntityVersion MinVersion => new EntityVersion(ulong.MinValue);

        public static ulong FromBytes(byte[] bytes)
        {
            return BitConverter.ToUInt64(bytes.Reverse().ToArray(), 0);
        }

        public byte[] ToBytes()
        {
            return BitConverter.GetBytes(Version).Reverse().ToArray();
        }

        protected override bool EqualsCore(EntityVersion other)
        {
            return Version == other.Version;
        }

        protected override int GetHashCodeCore()
        {
            return Version.GetHashCode();
        }
    }
}
