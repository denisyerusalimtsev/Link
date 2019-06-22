using Link.Common.Domain.Framework.Communication;
using Link.ReportManagement.Infrastructure.Messaging.ConfigurationOptions;
using Link.ReportManagement.Infrastructure.Messaging.Interfaces;
using Link.ReportManagement.Infrastructure.Models.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Link.ReportManagement.Infrastructure.Messaging.Services
{
    public class EmailService : IEmailService
    {
        private readonly Configurations _configurations;
        private readonly ICommunicationChannel _communicationChannel;

        public EmailService(IConfiguration configurations,
            ICommunicationChannel communicationChannel)
        {
            _configurations = new Configurations(configurations);
            _communicationChannel = communicationChannel;
        }

        public async Task SendFinishEventEmail(string fileName, UserDto user, EventDto ev)
        {
            var emailParameters = new EmailParameters(user, ev);
            await _communicationChannel.SynchronousPostRequestAsync(
                string.Concat(_configurations.EmailManagementUrl, $"report/{fileName}"), emailParameters);
        }
    }
}
