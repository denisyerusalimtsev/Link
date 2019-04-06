using Link.UserManagement.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link.UserManagement.Application.Features.GetUser;
using Link.UserManagement.Infrastructure.Web.Models;
using Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models;

namespace Link.UserManagement.Infrastructure.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LinkApplication _app;
        public UserController(LinkApplication app)
        {
            _app = app;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            GetUserQueryResult result = await _app.RunQuery(new GetUserQuery());

            return Ok(new GetUserDto
            {
                Users = result.Users.Select(UserStorageDto.FromDomain).ToList()
            });
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
