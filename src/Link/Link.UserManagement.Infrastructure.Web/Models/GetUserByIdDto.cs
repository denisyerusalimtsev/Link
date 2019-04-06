using Link.UserManagement.Domain.Model.Entities;
using Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models;

namespace Link.UserManagement.Infrastructure.Web.Models
{
    public class GetUserByIdDto
    {
        public UserStorageDto User { get; set; }
    }
}
