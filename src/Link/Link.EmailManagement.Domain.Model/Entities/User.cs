using Link.Common.Domain.Framework.Models;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public User(UserId id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string Email { get; }
    }
}
