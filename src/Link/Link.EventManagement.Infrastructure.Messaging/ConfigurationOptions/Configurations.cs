using Microsoft.Extensions.Configuration;

namespace Link.EventManagement.Infrastructure.Messaging.ConfigurationOptions
{
    public class Configurations
    {
        public Configurations(IConfiguration config)
        {
            ExpertManagementUrl = config.GetSection("ExpertManagementUrl").Value;
        }

        public string ExpertManagementUrl { get; set; }
    }
}
