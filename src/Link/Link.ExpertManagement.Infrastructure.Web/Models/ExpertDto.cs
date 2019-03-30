using Link.ExpertManagement.Domain.Model.Entities;

namespace Link.ExpertManagement.Infrastructure.Web.Models
{
    public class ExpertDto
    {
        public ExpertDto(Expert expert)
        {
            Id = expert.Id.Id;
            FirstName = expert.FirstName;
            LastName = expert.LastName;
            Status = expert.Status.ToString();
            ContactInfo = expert.ContactInfo;
        }

        /// <summary>
        /// Expert id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        public string Status { get; set; }

        public ExpertContactInfo ContactInfo { get; set; }
    }
}
