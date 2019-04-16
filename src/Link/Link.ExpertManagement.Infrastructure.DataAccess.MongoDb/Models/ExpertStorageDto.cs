using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Enums;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ExpertStatus = Link.ExpertManagement.Domain.Model.Enums.ExpertStatus;

namespace Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models
{
    public class ExpertStorageDto
    {
        public static ExpertStorageDto FromDomain(Expert expert)
        {
            if (expert == null)
            {
                throw new ArgumentException("Expert is null.");
            }

            return new ExpertStorageDto
            {
                Id = expert.Id == null
                    ? new ObjectId()
                    : new ObjectId(expert.Id.Id),
                FirstName = expert.FirstName,
                LastName = expert.LastName,
                ExpertProfile = expert.ExpertProfile.ToString(),
                Type = expert.Type.ToString(),
                Status = expert.Status.ToString(),
                Email = expert.ContactInfo.Email,
                PhoneNumber = expert.ContactInfo.PhoneNumber,
                LinkedInUrl = expert.ContactInfo.LinkedInUrl
            };
        }

        public Expert ToDomain()
        {
            return new Expert(
                id: new ExpertId(Id.ToString()),
                firstName: FirstName,
                lastName: LastName,
                expertProfile: Enum.Parse<ExpertProfile>(ExpertProfile),
                status: Enum.Parse<ExpertStatus>(Status),
                type: Enum.Parse<ExpertType>(Type),
                contactInfo: new ExpertContactInfo(
                    email: Email,
                    phoneNumber: PhoneNumber,
                    linkedInUrl: LinkedInUrl)
            );
        }

        [BsonElement("id")]
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("expertProfile")]
        public string ExpertProfile { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("linkedInUrl")]
        public string LinkedInUrl { get; set; }
    }
}