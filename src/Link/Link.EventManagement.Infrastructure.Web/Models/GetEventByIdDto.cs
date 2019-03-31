using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class GetEventByIdDto
    {
        public EventStorageDto Event { get; set; }
    }
}
