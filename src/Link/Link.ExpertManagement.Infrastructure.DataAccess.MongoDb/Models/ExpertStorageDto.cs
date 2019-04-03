using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Enums;
using System;
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

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ExpertProfile { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string LinkedInUrl { get; set; }
    }
}
