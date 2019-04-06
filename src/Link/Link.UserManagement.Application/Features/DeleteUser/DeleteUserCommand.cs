using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;

namespace Link.UserManagement.Application.Features.DeleteUser
{
    public sealed class DeleteUserCommand : ICommand<DeleteUserCommand.Reply>
    {
        public DeleteUserCommand(UserId id)
        {
            Id = id;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(UserId id)
            {
                Id = id;
            }

            public UserId Id { get; }
        }

        public UserId Id { get; }
    }
}
