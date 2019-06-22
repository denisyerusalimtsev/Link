using System.IO;
using System.Threading.Tasks;

namespace Link.EmailManagement.Domain.Services.Interfaces
{
    public interface IAzureBlobClient
    {
        Task<MemoryStream> UploadFromBlob(string fileName);
    }
}
