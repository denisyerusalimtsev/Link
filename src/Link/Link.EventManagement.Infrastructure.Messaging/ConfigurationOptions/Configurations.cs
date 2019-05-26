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
        }

        public string ExpertManagementUrl { get; set; }

        public string UserManagementUrl { get; set; }

        public string EmailManagementUrl { get; set; }
    }
}
