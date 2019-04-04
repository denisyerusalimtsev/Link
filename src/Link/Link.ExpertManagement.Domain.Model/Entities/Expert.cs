using Link.Common.Domain.Framework.Models;
using Link.ExpertManagement.Domain.Model.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Link.ExpertManagement.Domain.Model.Entities
{
    public sealed class Expert : AggregateRoot<ExpertId>
    {
        public Expert(
            ExpertId id,
            string firstName, 
            string lastName,
            ExpertProfile expertProfile, 
            ExpertStatus status,
            ExpertType type, 
            ExpertContactInfo contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ExpertProfile = expertProfile;
            Status = status;
            Type = type;
            ContactInfo = contactInfo;
        }

        [BsonElement("firstName")]
        public string FirstName { get; }

        [BsonElement("lastName")]
        public string LastName { get; }

        [BsonElement("expertProfile")]
        public ExpertProfile ExpertProfile { get; }

        [BsonElement("status")]
        public ExpertStatus Status { get; }

        [BsonElement("type")]
        public ExpertType Type { get; }

        public ExpertContactInfo ContactInfo { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
