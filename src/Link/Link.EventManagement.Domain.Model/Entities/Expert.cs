using System;
using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using Type = Link.EventManagement.Domain.Model.Enums.Type;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class Expert : Entity<Expert>
    {
        public Expert(string id, string firstName, string lastName, string type, string status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Type = Enum.Parse<Type>(type);
            Status = Enum.Parse<ExpertStatus>(status);
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Type Type { get; set; }

        public ExpertStatus Status { get; set; }
    }
}
