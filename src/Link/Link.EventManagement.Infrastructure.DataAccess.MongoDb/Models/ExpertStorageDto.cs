using Link.EventManagement.Domain.Model.Entities;
using System;

namespace Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models
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
                Id = expert.Id,
                FirstName = expert.FirstName,
                LastName = expert.LastName,
                Type = expert.ExpertType.ToString(),
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
                expertDto.Id,
                expertDto.FirstName,
                expertDto.LastName,
                expertDto.Type,
                expertDto.Status,
                new ExpertContactInfo(
                    expertDto.Email,
                    expertDto.PhoneNumber,
                    expertDto.LinkedInUrl)
            );
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string LinkedInUrl { get; set; }
    }
}
