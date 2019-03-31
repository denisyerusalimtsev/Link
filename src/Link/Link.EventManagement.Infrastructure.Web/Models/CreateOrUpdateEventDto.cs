using Link.EventManagement.Domain.Model.Enums;
using Type = Link.EventManagement.Domain.Model.Enums.Type;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class CreateOrUpdateEventDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public Type Type { get; set; }

        public Status Status { get; set; }

        public int CountOfNeededExperts { get; set; }
    }
}
