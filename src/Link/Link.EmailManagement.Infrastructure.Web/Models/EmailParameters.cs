using Link.EmailManagement.Infrastructure.Models.Models;

namespace Link.EmailManagement.Infrastructure.Web.Models
{
    public class EmailParameters
    {
        public UserDto User { get; set; }

        public EventDto Event { get; set; }
    }
}
