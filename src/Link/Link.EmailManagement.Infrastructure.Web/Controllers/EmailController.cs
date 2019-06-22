using Link.EmailManagement.Application;
using Link.EmailManagement.Application.Features.SendInviteEmail;
using Link.EmailManagement.Application.Features.SendNotificationEmail;
using Link.EmailManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Link.EmailManagement.Infrastructure.Web.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly LinkApplication _app;

        public EmailController(LinkApplication app)
        {
            _app = app;
        }

        [HttpPost]
        [Route("report/{fileName}")]
        public async Task<IActionResult> SendReport([FromRoute] string fileName, [FromBody] EmailParameters parameters)
        {
            SendNotificationEmailQueryResult result = 
                await _app.RunQuery(
                    new SendNotificationEmailQuery(fileName, parameters.User, parameters.Event));

            return Ok("Email was sent");
        }

        [HttpPost]
        [Route("invite")]
        public async Task<IActionResult> Invite([FromBody] InviteParameters parameters)
        {
            SendInviteEmailQueryResult result =
                await _app.RunQuery(new SendInviteEmailQuery(
                    parameters.Experts,
                    parameters.Event));

            return Ok("Email was sent");
        }
    }
}
