using System.Collections.Generic;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.EventManagement.Infrastructure.Web.Models
{
    public class GetEventDto
    {
        public List<EventStorageDto> Events { get; set; }
    }
}
