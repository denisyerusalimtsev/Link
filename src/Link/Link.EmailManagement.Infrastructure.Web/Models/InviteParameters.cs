using System.Collections.Generic;
using Link.EmailManagement.Infrastructure.Models.Models;

namespace Link.EmailManagement.Infrastructure.Web.Models
{
    public class InviteParameters
    {
        public EventDto Event { get; set; }

        public List<ExpertDto> Experts { get; set; }
    }
}
