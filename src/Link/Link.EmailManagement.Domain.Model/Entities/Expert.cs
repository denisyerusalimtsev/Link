using System;
using Link.Common.Domain.Framework.Models;
using Link.EmailManagement.Domain.Model.Enums;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public class Expert : Entity<Expert>
    {
        public Expert(string id, string firstName, string lastName, string type, string status, ExpertContactInfo contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactInfo = contactInfo;
            ExpertType = Enum.Parse<ExpertType>(type);
            Status = Enum.Parse<ExpertStatus>(status);
        }

        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public ExpertContactInfo ContactInfo { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
