using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;

namespace Link.UserManagement.Application.Features.AddOrUpdateUser
{
    public sealed class AddOrUpdateUserCommand : ICommand<AddOrUpdateUserCommand.Reply>
    {
        public AddOrUpdateUserCommand(
            UserId id, 
            string firstName, 
            string lastName,
            string phoneNumber,
            string email,
            string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(UserId id)
            {
                Id = id;
            }

            public UserId Id { get; }
        }

        public UserId Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
