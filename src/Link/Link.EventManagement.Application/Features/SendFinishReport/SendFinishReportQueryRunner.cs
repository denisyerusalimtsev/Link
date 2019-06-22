using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Services.Interfaces;
using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using Link.EventManagement.Infrastructure.Messaging.Interfaces;
using Link.EventManagement.Infrastructure.Messaging.Models;
using System;
using System.Threading.Tasks;

namespace Link.EventManagement.Application.Features.SendFinishReport
{
    public sealed class SendFinishReportQueryRunner :
        QueryRunner<SendFinishReportQuery, SendFinishReportQueryResult>
    {
        private readonly IEventRepository _events;
        private readonly IUserService _userService;
        private readonly IExpertService _expertService;
        private readonly IReportService _reportService;

        public SendFinishReportQueryRunner(
            IEventRepository events,
            IUserService userService,
            IExpertService expertService,
            IReportService reportService)
        {
            _events = events;
            _userService = userService;
            _expertService = expertService;
            _reportService = reportService;
        }

        public override async Task<SendFinishReportQueryResult> Run(SendFinishReportQuery query)
        {
            try
            {
                var ev = await _events.Get(query.EventId);

                EventStorageDto eventDto = EventStorageDto.FromDomain(ev);
                GetUserDto userDto = await _userService.GetUser(ev.UserId);
                GetExpertsDto expertsDto = await _expertService.GetExperts(ev.ExpertIds);

                ReportParameters parameters = new ReportParameters(userDto.User, eventDto, expertsDto.Experts);
                await _reportService.GetReportAsync(parameters);
              
                return new SendFinishReportQueryResult();
            }
            catch (Exception e)
            {
                return new SendFinishReportQueryResult(e.Message);
            }  
        }
    }
}
