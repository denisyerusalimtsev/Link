using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class ReportParameters
    {
        public ReportParameters(UserStorageDto user, EventStorageDto ev, List<ExpertStorageDto> experts)
        {
            User = user;
            Event = ev;
            Experts = experts;
        }

        public UserStorageDto User { get; set; }

        public EventStorageDto Event { get; set; }

        public List<ExpertStorageDto> Experts { get; set; }
    }
}
