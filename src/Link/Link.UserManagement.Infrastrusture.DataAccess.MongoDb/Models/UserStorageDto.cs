using Link.UserManagement.Domain.Model.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

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
                Id = user.Id == null
                    ? new ObjectId()
                    : new ObjectId(user.Id.Id),
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
        }
        public User ToDomain()
        {
            return new User(
                id: new UserId(Id.ToString()), 
                firstName: FirstName,
                lastName: LastName,
                phoneNumber: PhoneNumber,
                email: Email
            );
        }

        [BsonElement]
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("passwordHash")]
        public byte[] PasswordHash { get; set; }

        [BsonElement("passwordSalt")]
        public byte[] PasswordSalt { get; set; }
    }
}
