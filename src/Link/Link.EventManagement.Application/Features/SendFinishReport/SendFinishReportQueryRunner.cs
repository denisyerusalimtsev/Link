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

                var eventDto = EventStorageDto.FromDomain(ev);
                var userDto = await _userService.GetUser(ev.UserId);
                var expertsDto = await _expertService.GetExperts(ev.ExpertIds);

                var parameters = new ReportParameters(userDto.User, eventDto, expertsDto.Experts);
                var report = await _reportService.GetReportAsync(parameters);
                var finishReportDto = new FinishEventDto(userDto.User, report.Report);

                await _userService.SendFinishEventEmail(finishReportDto);

                return new SendFinishReportQueryResult();
            }
            catch (Exception e)
            {
                return new SendFinishReportQueryResult(e.Message);
            }  
        }
    }
}
