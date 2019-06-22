using Link.EmailManagement.Domain.Services.Interfaces;
using Link.EmailManagement.Infrastructure.Services.ConfigurationOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace Link.EmailManagement.Infrastructure.Services.Services
{
    public class AzureBlobClient : IAzureBlobClient
    {
        private readonly Configurations _configurations;

        public AzureBlobClient(IConfiguration configurations)
        {
            _configurations = new Configurations(configurations);
        }

        public async Task<MemoryStream> UploadFromBlob(string fileName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_configurations.AzureCloudStorageAccount);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference("linkblob");
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
            MemoryStream report = new MemoryStream();
            await blockBlob.DownloadToStreamAsync(report);

            return report;
        }
    }
}
