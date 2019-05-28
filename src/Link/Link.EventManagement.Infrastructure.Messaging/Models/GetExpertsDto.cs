using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class GetExpertsDto
    {
        public List<ExpertStorageDto> Experts { get; set; }
    }
}
