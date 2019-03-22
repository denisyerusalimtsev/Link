namespace Link.EventManagement.Application.Frameworks
{
    public interface ICommandValidator<in T, TR>
        where T : ICommand<TR>
        where TR : ICommandReply
    {
        void Validate(T command);
    }
}
