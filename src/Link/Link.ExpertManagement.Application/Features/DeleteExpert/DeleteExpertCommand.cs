using Link.Common.Domain.Framework.Frameworks;
using Link.ExpertManagement.Domain.Model.Entities;

namespace Link.ExpertManagement.Application.Features.DeleteExpert
{
    public sealed class DeleteExpertCommand : ICommand<DeleteExpertCommand.Reply>
    {
        public DeleteExpertCommand(ExpertId id)
        {
            Id = id;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(ExpertId id)
            {
                Id = id;
            }

            public ExpertId Id { get; }
        }

        public ExpertId Id { get; }
    }
}
