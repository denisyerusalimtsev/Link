using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Enums;
using System;
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
                Id = expert.Id.Id,
                FirstName = expert.FirstName,
                LastName = expert.LastName,
                Type = expert.Type.ToString(),
                Status = expert.Status.ToString()
            };
        }
        public static Expert ToDomain(ExpertStorageDto expertDto)
        {
            if (expertDto == null)
            {
                throw new ArgumentException("Expert is null.");
            }

            return new Expert(
                id: new ExpertId(expertDto.Id), 
                firstName: expertDto.FirstName,
                lastName: expertDto.LastName,
                expertProfile: Enum.Parse<ExpertProfile>(expertDto.ExpertProfile),
                status: Enum.Parse<ExpertStatus>(expertDto.Status),
                type: Enum.Parse<ExpertType>(expertDto.Type),
                contactInfo: new ExpertContactInfo(
                    expertDto.Email,
                    expertDto.PhoneNumber,
                    expertDto.LinkedInUrl)
            );
        }

        [BsonElement("id")]
        public string Id { get; set; }

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
