using System.Threading.Tasks;

namespace Link.Common.Domain.Framework.Frameworks
{
    public interface ICommandHandler
    {
        Task<TR> Handle<TR>(ICommand<TR> command) where TR : class, ICommandReply;
    }
}
