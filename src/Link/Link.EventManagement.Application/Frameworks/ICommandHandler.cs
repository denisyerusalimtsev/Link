using System.Threading.Tasks;

namespace Link.EventManagement.Application.Frameworks
{
    public interface ICommandHandler
    {
        Task<TR> Handle<TR>(ICommand<TR> command) where TR : class, ICommandReply;
    }
}
