using Link.Common.Domain.Framework.Models;

namespace Link.ExpertManagement.Domain.Model.Entities
{
    public class ExpertContactInfo : ValueObject<ExpertContactInfo>
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string LinkedInUrl { get; }

        protected override bool EqualsCore(ExpertContactInfo other)
        {
            throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }
    }
}
