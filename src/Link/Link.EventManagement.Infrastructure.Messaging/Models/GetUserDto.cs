using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class GetUserDto
    {
        public UserStorageDto User { get; set; }
    }
}
