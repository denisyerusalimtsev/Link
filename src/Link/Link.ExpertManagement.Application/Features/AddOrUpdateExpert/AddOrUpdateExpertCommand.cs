using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Enums;

namespace Link.ExpertManagement.Application.Features.AddOrUpdateExpert
{
    public sealed class AddOrUpdateExpertCommand : ICommand<AddOrUpdateExpertCommand.Reply>
    {
        public AddOrUpdateExpertCommand(
            ExpertId id, 
            string firstName,
            string lastName, 
            ExpertProfile expertProfile,
            ExpertStatus status, 
            ExpertType type, 
            string email,
            string phoneNumber,
            string linkedInUrl)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ExpertProfile = expertProfile;
            Status = status;
            Type = type;
            ContactInfo = new ExpertContactInfo(email, phoneNumber, linkedInUrl);
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(ExpertId id)
            {
                Id = id;
            }

            public ExpertId Id { get; }
        }

        public ExpertId Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public ExpertProfile ExpertProfile { get; }

        public ExpertStatus Status { get; }

        public ExpertType Type { get; }

        public ExpertContactInfo ContactInfo { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
