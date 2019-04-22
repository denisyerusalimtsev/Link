using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EmailManagement.Application;
using Link.EmailManagement.Application.Features.SendNotificationEmail;
using Link.EmailManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Link.EmailManagement.Infrastructure.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly LinkApplication _app;

        public EmailController(LinkApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] EmailParameters parameters)
        {
            SendNotificationEmailQueryResult result = 
                await _app.RunQuery(new SendNotificationEmailQuery(
                    parameters.Experts,
                    parameters.Event, 
                    parameters.Attachments));

            return Ok("Email was sent");
        }
    }
}
