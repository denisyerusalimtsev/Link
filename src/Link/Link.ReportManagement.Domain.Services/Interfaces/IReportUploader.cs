using System.Threading.Tasks;

namespace Link.ReportManagement.Domain.Services.Interfaces
{
    public interface IReportUploader
    {
        Task<string> UploadToBlodAsync(string fileName, byte[] fileData, string fileMimeType);
    }
}
