using System.IO;
using System.Security.Cryptography.X509Certificates;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class FinishEventDto
    {
        public FinishEventDto(UserStorageDto user, MemoryStream report)
        {
            User = user;
            Report = report;
        }

        public UserStorageDto User { get; set; }

        public MemoryStream Report { get; set; }
    }
}
