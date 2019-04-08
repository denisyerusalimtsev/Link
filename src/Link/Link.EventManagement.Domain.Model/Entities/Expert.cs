using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using System;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class Expert : Entity<Expert>
    {
        public Expert(string id, string firstName, string lastName, string type, string status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ExpertType = Enum.Parse<ExpertType>(type);
            Status = Enum.Parse<ExpertStatus>(status);
        }

        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }
    }
}
