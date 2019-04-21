using Link.Common.Domain.Framework.Frameworks;
using Link.UserManagement.Domain.Model.Entities;
using Link.UserManagement.Domain.Model.Interfaces;
using System.Threading.Tasks;

namespace Link.UserManagement.Application.Features.AddOrUpdateUser
{
    public sealed class AddOrUpdateUserCommandHandler
        : CommandHandler<AddOrUpdateUserCommand, AddOrUpdateUserCommand.Reply>
    {
        private readonly IUserRepository _users;

        public AddOrUpdateUserCommandHandler(
            ICommandValidator<AddOrUpdateUserCommand, AddOrUpdateUserCommand.Reply> validator,
            IUserRepository users)
            : base(validator)
        {
            _users = users;
        }

        protected override async Task<AddOrUpdateUserCommand.Reply> Handle(AddOrUpdateUserCommand command)
        {
            var user = new User(
                command.Id,
                command.FirstName,
                command.LastName,
                command.PhoneNumber,
                command.Email
            );

            if (user.Id.Id == null)
            {
                User newUser = await _users.Create(user);

                return new AddOrUpdateUserCommand.Reply(newUser.Id);
            }

            User existedUser = await _users.Get(command.Id);
            if (existedUser != null)
            {
                _users.Update(command.Id, user);
            }

            return new AddOrUpdateUserCommand.Reply(command.Id);
        }
    }
}