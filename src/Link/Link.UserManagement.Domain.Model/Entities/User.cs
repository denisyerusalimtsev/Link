using Link.Common.Domain.Framework.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Link.UserManagement.Domain.Model.Entities
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

        [BsonElement("firstName")]
        public string FirstName { get; }

        [BsonElement("lastName")]
        public string LastName { get; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; }

        [BsonElement("email")]
        public string Email { get; }

        [BsonElement("passwordHash")]
        public byte[] PasswordHash { get; }

        [BsonElement("passwordSalt")]
        public byte[] PasswordSalt { get; }
    }
}
