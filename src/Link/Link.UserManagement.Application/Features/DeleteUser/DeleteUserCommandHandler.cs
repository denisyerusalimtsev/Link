using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Interfaces;
using System.Threading.Tasks;

namespace Link.UserManagement.Application.Features.DeleteUser
{
    public sealed class DeleteUserCommandHandler
        : CommandHandler<DeleteUserCommand, DeleteUserCommand.Reply>
    {
        private readonly IUserRepository _users;

        public DeleteUserCommandHandler(
            ICommandValidator<DeleteUserCommand, DeleteUserCommand.Reply> validator,
            IUserRepository users) : base(validator)
        {
            _users = users;
        }

        protected override Task<DeleteUserCommand.Reply> Handle(DeleteUserCommand command)
        {
            _users.Remove(command.Id);

            return Task.FromResult(new DeleteUserCommand.Reply(command.Id));
        }
    }
}
