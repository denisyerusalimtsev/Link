using Link.UserManagement.Domain.Model.Entities;

namespace Link.UserManagement.Infrastructure.Web.Models
{
    public class AddOrUpdateUserDto
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
