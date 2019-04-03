using Link.ExpertManagement.Application;
using Link.ExpertManagement.Application.Features.GetExpert;
using Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.ExpertManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Infrastructure.Web.Controllers
{
    [Route("experts")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        private readonly LinkApplication _app;
        public ExpertController(LinkApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetExpertQueryResult result = await _app.RunQuery(new GetExpertQuery());

            return Ok(new GetExpertDto
            {
                Experts = result.Experts.Select(ExpertStorageDto.FromDomain).ToList()
            });
        }
    }
}
