using Link.Common.Domain.Framework.Communication;
using Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Services
{
    public class ReportService : IReportService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public ReportService(
            IConfiguration config,
            ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(config);
            _communicationChannel = communicationChannel;
        }

        public async Task<GenerateReportDto> GetReportAsync(ReportParameters parameters)
        {
            return await _communicationChannel
                .SynchronousPostRequest<ReportParameters, GenerateReportDto>(
                    _configurations.ReportManagementUrl, parameters);
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
