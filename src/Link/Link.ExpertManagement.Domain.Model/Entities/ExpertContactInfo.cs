using Link.Common.Domain.Framework.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Link.ExpertManagement.Domain.Model.Entities
{
    public class ExpertContactInfo : ValueObject<ExpertContactInfo>
    {
        public ExpertContactInfo(string email, string phoneNumber, string linkedInUrl)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            LinkedInUrl = linkedInUrl;
        }

        [BsonElement("email")]
        public string Email { get; }

        [BsonElement("phoneNumber")]

        public string PhoneNumber { get; }

        [BsonElement("linkedInUrl")]
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
