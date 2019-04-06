using Link.UserManagement.Application;
using Link.UserManagement.Application.Features.AddOrUpdateUser;
using Link.UserManagement.Application.Features.GetUser;
using Link.UserManagement.Application.Features.GetUserById;
using Link.UserManagement.Domain.Model.Entities;
using Link.UserManagement.Infrastructure.Web.Models;
using Link.UserManagement.Infrastrusture.DataAccess.MongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link.UserManagement.Application.Features.DeleteUser;

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
        public async Task<ActionResult<string>> Get(string id)
        {
            var query = new GetUserByIdQuery(new UserId(id));
            GetUserByIdQueryResult result = await _app.RunQuery(query);
            var user = UserStorageDto.FromDomain(result.User);

            return Ok(new GetUserByIdDto
            {
                User = user
            });
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] AddOrUpdateUserDto dto)
        {
            AddOrUpdateUserCommand command = new AddOrUpdateUserCommand(
                id: new UserId(dto.Id), 
                firstName: dto.FirstName,
                lastName: dto.LastName,
                phoneNumber: dto.PhoneNumber,
                email: dto.Email,
                password: dto.Password);

            AddOrUpdateUserCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new AddOrUpdateUserDto
            {
                Id = reply.Id.Id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteUserCommand(id: new UserId(id));

            DeleteUserCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new DeleteUserDto
            {
                Id = reply.Id.Id
            });
        }
    }
}
