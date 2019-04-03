using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Entities;
using Link.ExpertManagement.Domain.Model.Interfaces;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Application.Features.AddOrUpdateExpert
{
    public sealed class AddOrUpdateExpertCommandHandler
        : CommandHandler<AddOrUpdateExpertCommand, AddOrUpdateExpertCommand.Reply>
    {
        private readonly IExpertRepository _experts;

        public AddOrUpdateExpertCommandHandler(
            ICommandValidator<AddOrUpdateExpertCommand, AddOrUpdateExpertCommand.Reply> validator,
            IExpertRepository experts)
            : base(validator)
        {
            _experts = experts;
        }

        protected override async Task<AddOrUpdateExpertCommand.Reply> Handle(AddOrUpdateExpertCommand command)
        {
            Expert expert = new Expert(
                command.Id,
                command.FirstName,
                command.LastName,
                command.ExpertProfile,
                command.Status,
                command.Type,
                command.ContactInfo
            );

            Expert existedExpert = await _experts.Get(command.Id);
            if (existedExpert != null)
            {
                _experts.Update(command.Id, expert);

                return new AddOrUpdateExpertCommand.Reply(command.Id);
            }

            Expert newExpert = await _experts.Create(expert);

            return new AddOrUpdateExpertCommand.Reply(newExpert.Id);
        }
    }
}