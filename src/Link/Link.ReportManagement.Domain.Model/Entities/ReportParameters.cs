using System.Collections.Generic;
using Link.ReportManagement.Infrastructure.Models.Models;

namespace Link.ReportManagement.Domain.Model.Entities
{
    public class ReportParameters
    {
        public UserDto User { get; set; }

        public EventDto Event { get; set; }

        public List<ExpertDto> Experts { get; set; }
    }
}
