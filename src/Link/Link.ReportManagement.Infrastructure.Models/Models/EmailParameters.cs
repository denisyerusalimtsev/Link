namespace Link.ReportManagement.Infrastructure.Models.Models
{
    public class EmailParameters
    {
        public EmailParameters(UserDto user, EventDto ev)
        {
            User = user;
            Event = ev;
        }

        public UserDto User { get; set; }

        public EventDto Event { get; set; }
    }
}
