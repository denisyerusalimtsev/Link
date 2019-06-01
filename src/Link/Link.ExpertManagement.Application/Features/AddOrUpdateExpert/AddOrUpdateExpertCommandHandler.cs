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

        protected override async Task<AddOrUpdateExpertCommand.Reply> HandleAsync(AddOrUpdateExpertCommand command)
        {
            Expert expert = new Expert(
                id: command.Id,
                firstName: command.FirstName,
                lastName: command.LastName,
                expertProfile: command.ExpertProfile,
                status: command.Status,
                type: command.Type,
                contactInfo: command.ContactInfo
            );

            if (expert.Id == null)
            {
                Expert newExpert = await _experts.Create(expert);

                return new AddOrUpdateExpertCommand.Reply(newExpert.Id);
            }

            Expert existedExpert = await _experts.Get(command.Id);
            if (existedExpert != null)
            {
                _experts.Update(command.Id, expert);
            }
            
            return new AddOrUpdateExpertCommand.Reply(command.Id);
        }
    }
}