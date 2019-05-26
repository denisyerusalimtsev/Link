using Link.EmailManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.EmailManagement.Infrastructure.Web.Models
{
    public class InviteParameters
    {
        public Event Event { get; set; }

        public List<Expert> Experts { get; set; }
    }
}
