using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Interfaces;

namespace Link.ExpertManagement.Application.Features.DeleteExpert
{
    public sealed class DeleteExpertCommandHandler
        : CommandHandler<DeleteExpertCommand, DeleteExpertCommand.Reply>
    {
        private readonly IExpertRepository _experts;

        public DeleteExpertCommandHandler(
            ICommandValidator<DeleteExpertCommand, DeleteExpertCommand.Reply> validator,
            IExpertRepository experts) : base(validator)
        {
            _experts = experts;
        }

        protected override Task<DeleteExpertCommand.Reply> Handle(DeleteExpertCommand command)
        {
            _experts.Remove(command.Id);

            return Task.FromResult(new DeleteExpertCommand.Reply(command.Id));
        }
    }
}
