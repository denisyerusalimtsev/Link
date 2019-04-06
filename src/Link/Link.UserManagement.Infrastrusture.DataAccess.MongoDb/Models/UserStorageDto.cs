using System;
using Link.UserManagement.Domain.Model.Entities;

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
        public static User ToDomain(UserStorageDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentException("User is null.");
            }

            return new User(
                id: new UserId(userDto.Id),
                firstName: userDto.FirstName,
                lastName: userDto.LastName,
                phoneNumber: userDto.PhoneNumber,
                email: userDto.Email
            );
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
