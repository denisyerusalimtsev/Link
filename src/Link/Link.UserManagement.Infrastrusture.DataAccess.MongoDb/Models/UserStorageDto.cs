using System;
using Link.UserManagement.Domain.Model.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models
{
    public class UserStorageDto
    {
        public static UserStorageDto FromDomain(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User is null.");
            }

            return new UserStorageDto
            {
                Id = user.Id.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
        }
        public User ToDomain()
        {
            return new User(
                id: new UserId(Id),
                firstName: FirstName,
                lastName: LastName,
                phoneNumber: PhoneNumber,
                email: Email
            );
        }

        [BsonElement]
        [BsonId]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("lhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("passwordHash")]
        public byte[] PasswordHash { get; set; }

        [BsonElement("asswordSalt")]
        public byte[] PasswordSalt { get; set; }
    }
}
