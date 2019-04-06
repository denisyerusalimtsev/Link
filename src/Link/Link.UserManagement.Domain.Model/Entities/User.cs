using Link.Common.Domain.Framework.Models;

namespace Link.UserManagement.Domain.Model.Entities
{
    public class User : AggregateRoot<User>
    {
        public User(UserId id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public UserId Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public byte[] PasswordHash { get; }

        public byte[] PasswordSalt { get; }
    }
}
