using Link.Common.Domain.Framework.Models;
using Link.ExpertManagement.Domain.Model.Enums;

namespace Link.ExpertManagement.Domain.Model.Entities
{
    public class Expert : AggregateRoot<ExpertId>
    {
        public override ExpertId Id { get; protected set; }

        public string FirstName { get; }

        public string LastName { get; }

        public ExpertProfile ExpertProfile { get; }

        public ExpertStatus Status { get; }

        public ExpertContactInfo ContactInfo { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
