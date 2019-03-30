using Link.EventManagement.Application;
using Link.EventManagement.Application.Features.AddOrUpdateEvent;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Web.Controllers
{
    [Route("events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly LinkApplication _app;

        public EventController(LinkApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateEventDto dto)
        {
            var command = new AddOrUpdateEventCommand(
                id: new EventId(dto.Id),
                userId: new UserId(dto.UserId),
                name: dto.Name,
                type: dto.Type,
                status: dto.Status,
                countOfNeededExperts: dto.CountOfNeededExperts);

            AddOrUpdateEventCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new CreateOrUpdateEventResponseDto
            {
                EventId = reply.Id.Id
            });
        }
    }
}