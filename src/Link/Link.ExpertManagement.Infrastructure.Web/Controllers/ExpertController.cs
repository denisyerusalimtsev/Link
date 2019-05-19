using Link.ExpertManagement.Application;
using Link.ExpertManagement.Application.Features.AddOrUpdateExpert;
using Link.ExpertManagement.Application.Features.DeleteExpert;
using Link.ExpertManagement.Application.Features.GetExpert;
using Link.ExpertManagement.Application.Features.GetExpertById;
using Link.ExpertManagement.Application.Features.GetManyExpertsByIds;
using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.ExpertManagement.Infrastructure.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Infrastructure.Web.Controllers
{
    [Route("api/experts")]
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            GetExpertByIdQuery query = new GetExpertByIdQuery(id);
            GetExpertByIdQueryResult result = await _app.RunQuery(query);
            ExpertStorageDto expert = ExpertStorageDto.FromDomain(result.Expert);

            return Ok(new GetExpertByIdDto
            {
                Expert = expert
            });
        }

        [HttpGet]
        [Route("experts")]
        public async Task<IActionResult> Get([FromBody] List<ExpertId> expertIds)
        {
            GetManyExpertsByIdsQuery query = new GetManyExpertsByIdsQuery(expertIds);
            GetManyExpertsByIdsQueryResult result = await _app.RunQuery(query);

            return Ok(new GetExpertDto
            {
                Experts = result.Experts.Select(ExpertStorageDto.FromDomain).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrUpdateExpertDto dto)
        {
            AddOrUpdateExpertCommand command = new AddOrUpdateExpertCommand(
                id: null,
                firstName: dto.FirstName,
                lastName: dto.LastName,
                expertProfile: dto.ExpertProfile,
                status: dto.Status,
                type: dto.Type,
                email: dto.Email,
                phoneNumber: dto.PhoneNumber,
                linkedInUrl: dto.LinkedInUrl);

            AddOrUpdateExpertCommand.Reply reply = await _app.HandleCommand(command);
            return Ok(new AddOrUpdateExpertDto
            {
                Id = reply.Id.Id
            });

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] AddOrUpdateExpertDto dto)
        {
            AddOrUpdateExpertCommand command = new AddOrUpdateExpertCommand(
                id: new ExpertId(dto.Id),
                firstName: dto.FirstName,
                lastName: dto.LastName,
                expertProfile: dto.ExpertProfile,
                status: dto.Status,
                type: dto.Type,
                email: dto.Email,
                phoneNumber: dto.PhoneNumber,
                linkedInUrl: dto.LinkedInUrl);

            AddOrUpdateExpertCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new AddOrUpdateExpertDto
            {
                Id = reply.Id.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteExpertCommand command = new DeleteExpertCommand(id: new ExpertId(id));

            DeleteExpertCommand.Reply reply = await _app.HandleCommand(command);

            return Ok(new DeleteExpertDto
            {
                ExpertId = reply.Id.Id
            });
        }
    }
}
