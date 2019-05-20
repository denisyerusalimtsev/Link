using Link.EventManagement.Application;
using Link.EventManagement.Application.Features.AddOrUpdateEvent;
using Link.EventManagement.Application.Features.DeleteEvent;
using Link.EventManagement.Application.Features.GetEvent;
using Link.EventManagement.Application.Features.GetEventById;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Link.EventManagement.Application.Features.AssignExpertToEvent;

namespace Link.EventManagement.Infrastructure.Web.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly LinkApplication _app;

        public EventController(LinkApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetEventQueryResult result = await _app.RunQuery(new GetEventQuery());

            return Ok(new GetEventDto
            {
                Events = result.Events
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var query = new GetEventByIdQuery(new EventId(id));
            GetEventByIdQueryResult result = await _app.RunQuery(query);
            var ev = EventStorageDto.FromDomain(result.Event);

            return Ok(new GetEventByIdDto
            {
                Event = ev
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateEventDto dto)
        {
            var command = new AddOrUpdateEventCommand(
                id: null,
                userId: new UserId(dto.UserId),
                name: dto.Name,
                expertType: dto.ExpertType,
                status: dto.Status,
                latitude: dto.Latitude,
                longitude: dto.Longitude,
                startTime: dto.StartTime,
                endTime: dto.EndTime,
                countOfNeededExperts: dto.CountOfNeededExperts,
                experts: dto.Experts);

            AddOrUpdateEventCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new CreateOrUpdateEventResponseDto
            {
                EventId = reply.Id.Id
            });
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] AssignExpertsToEventDto dto)
        {
            var command = new AssignExpertToEventCommand(dto.EventId, dto.Experts);

            AssignExpertToEventCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new CreateOrUpdateEventResponseDto
            {
                EventId = reply.EventId.ToString()
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CreateOrUpdateEventDto dto)
        {
            var command = new AddOrUpdateEventCommand(
                id: new EventId(dto.Id),
                userId: new UserId(dto.UserId),
                name: dto.Name,
                expertType: dto.ExpertType,
                status: dto.Status,
                latitude: dto.Latitude,
                longitude: dto.Longitude,
                startTime: dto.StartTime,
                endTime: dto.EndTime,
                countOfNeededExperts: dto.CountOfNeededExperts,
                experts: dto.Experts);

            AddOrUpdateEventCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new CreateOrUpdateEventResponseDto
            {
                EventId = reply.Id.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteEventCommand(id: new EventId(id));

            DeleteEventCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new DeleteEventDto
            {
                Id = reply.Id.Id
            });
        }
    }
}