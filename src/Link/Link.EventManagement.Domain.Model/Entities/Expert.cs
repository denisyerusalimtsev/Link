using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using Type = System.Type;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class Expert : Entity<Expert>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Type Type { get; set; }

        public ExpertStatus Status { get; set; }
    }
}
