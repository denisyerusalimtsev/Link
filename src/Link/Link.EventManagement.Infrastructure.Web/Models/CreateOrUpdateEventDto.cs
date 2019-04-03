using Link.EventManagement.Domain.Model.Enums;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class CreateOrUpdateEventDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public ExpertType ExpertType { get; set; }

        public ExpertStatus Status { get; set; }

        public int CountOfNeededExperts { get; set; }
    }
}
