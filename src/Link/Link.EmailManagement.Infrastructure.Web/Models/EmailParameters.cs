using Link.EmailManagement.Domain.Model.Entities;
using System.Collections.Generic;
using System.IO;

namespace Link.EmailManagement.Infrastructure.Web.Models
{
    public class EmailParameters
    {
        public List<Expert> Experts { get; set; }

        public Event Event { get; set; }

        public Stream Attachments { get; set; }
    }
}
