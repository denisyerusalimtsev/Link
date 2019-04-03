using Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models;
using System.Collections.Generic;

namespace Link.ExpertManagement.Infrastructure.Web.Models
{
    public class GetExpertDto
    {
        public List<ExpertStorageDto> Experts { get; set; }
    }
}
