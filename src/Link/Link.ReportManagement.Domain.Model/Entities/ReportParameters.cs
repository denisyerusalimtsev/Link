using System.Collections.Generic;

namespace Link.ReportManagement.Domain.Model.Entities
{
    public class ReportParameters
    {
        public User User { get; set; }

        public Event Event { get; set; }

        public List<Expert> Experts { get; set; }
    }
}
