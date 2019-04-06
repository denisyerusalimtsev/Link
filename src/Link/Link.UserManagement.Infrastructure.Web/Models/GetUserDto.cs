using System.Collections.Generic;
using Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models;

namespace Link.UserManagement.Infrastructure.Web.Models
{
    public class GetUserDto
    {
        public List<UserStorageDto> Users { get; set; }
    }
}
