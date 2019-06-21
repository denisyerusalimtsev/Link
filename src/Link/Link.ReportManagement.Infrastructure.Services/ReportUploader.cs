using Link.ReportManagement.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace Link.ReportManagement.Infrastructure.Services
{
    public class ReportUploader : IReportUploader
    {
        private readonly string _accessKey;

        public ReportUploader(IConfiguration config)
        {
            _accessKey = config.GetConnectionString("DefaultConnection");
        }

        public async Task<string> UploadToBlodAsync(string fileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                string containerName = "linkblob";
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                string fullFileName = GenerateFileName(fileName);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (fullFileName == null || fileData == null)
                    return string.Empty;

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                cloudBlockBlob.Properties.ContentType = fileMimeType;
                await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
                return fullFileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string GenerateFileName(string fileName)
        {
            return $"{Guid.NewGuid()}_{fileName}";
        }
    }
}
