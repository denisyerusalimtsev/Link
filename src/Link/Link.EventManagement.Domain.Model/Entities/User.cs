using Link.Common.Domain.Framework.Models;

namespace Link.EventManagement.Domain.Model.Entities
{
    public sealed class User : Entity<User>
    {
        public User(string id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Id { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string Email { get; }
    }
}
