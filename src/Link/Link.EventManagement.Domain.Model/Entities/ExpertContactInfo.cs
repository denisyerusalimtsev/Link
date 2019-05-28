using Link.Common.Domain.Framework.Models;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class ExpertContactInfo : Entity<ExpertContactInfo>
    {
        public ExpertContactInfo(string email, string phoneNumber, string linkedInUrl)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            LinkedInUrl = linkedInUrl;
        }

        public string Email { get; }

        public string PhoneNumber { get; }

        public string LinkedInUrl { get; }
    }
}
