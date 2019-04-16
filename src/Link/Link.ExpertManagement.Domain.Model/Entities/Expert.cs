using Link.Common.Domain.Framework.Models;
using Link.ExpertManagement.Domain.Model.Enums;

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

        public string FirstName { get; }

        public string LastName { get; }

        public ExpertProfile ExpertProfile { get; }

        public ExpertStatus Status { get; }

        public ExpertType Type { get; }

        public ExpertContactInfo ContactInfo { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
