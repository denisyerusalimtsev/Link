using Microsoft.Extensions.Configuration;

namespace Link.ReportManagement.Infrastructure.Messaging.ConfigurationOptions
{
    public class Configurations
    {
        public Configurations(IConfiguration config)
        {
            EmailManagementUrl = config.GetSection("EmailManagementUrl").Value;
        }

        public string EmailManagementUrl { get; set; }
    }
}
