using Microsoft.Extensions.Configuration;

namespace Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions
{
    public class Configurations
    {
        public Configurations(IConfiguration config)
        {
            ExpertManagementUrl = config.GetSection("ExpertManagementUrl").Value;
            UserManagementUrl = config.GetSection("UserManagementUrl").Value;
            EmailManagementUrl = config.GetSection("EmailManagementUrl").Value;
            ReportManagementUrl = config.GetSection("ReportManagementUrl").Value;
            IoTUrl = config.GetSection("IoTUrl").Value;
            AzureCloudStorageAccount = config.GetSection("AzureCloudStorageAccount").Value;
        }

        public string ExpertManagementUrl { get; set; }

        public string UserManagementUrl { get; set; }

        public string EmailManagementUrl { get; set; }

        public string ReportManagementUrl { get; set; }

        public string IoTUrl { get; set; }

        public string AzureCloudStorageAccount { get; set; }
    }
}
