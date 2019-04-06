using Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models;

namespace Link.ExpertManagement.Infrastructure.Web.Models
{
    public class GetExpertByIdDto
    {
        public ExpertStorageDto Expert { get; set; }
    }
}
