using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Enums;

namespace Link.ExpertManagement.Infrastructure.Web.Models
{
    public class AddOrUpdateExpertDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ExpertProfile ExpertProfile { get; set; }

        public ExpertStatus Status { get; set; }

        public ExpertType Type { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string LinkedInUrl { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
