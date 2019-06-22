using Microsoft.Extensions.Configuration;

namespace Link.EmailManagement.Infrastructure.Services.ConfigurationOptions
{
    public class Configurations
    {
        public Configurations(IConfiguration config)
        {
            AzureCloudStorageAccount = config.GetSection("AzureCloudStorageAccount").Value;
        }

        public string AzureCloudStorageAccount { get; set; }
    }
}
