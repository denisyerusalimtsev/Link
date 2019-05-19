using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class GetUsersDto
    {
        public List<UserStorageDto> Users { get; set; }
    }
}
