using Link.IoT.Application;
using Link.IoT.Application.Features.StartEvent;
using Link.IoT.Application.Features.StopEvent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Link.IoT.Infrastructure.Web.Controllers
{
    [Route("api/iot")]
    [ApiController]
    public class IoTController : ControllerBase
    {
        private readonly LinkApplication _application;

        public IoTController(LinkApplication application)
        {
            _application = application;
        }

        [HttpPost]
        [Route("start/{expertId}")]
        public async Task<IActionResult> StartEvent([FromRoute] string expertId)
        {
            var query = new StartEventQuery(expertId);
            await _application.RunQuery(query);

            return Ok();
        }

        [HttpPost]
        [Route("stop/{expertId}")]
        public async Task<IActionResult> StopEvent([FromRoute] string expertId)
        {
            var query = new StopEventQuery(expertId);
            await _application.RunQuery(query);

            return Ok();
        }
    }
}
