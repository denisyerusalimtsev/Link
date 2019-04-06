using Link.Common.Domain.Framework.Frameworks;

namespace Link.ExpertManagement.Application.Features.GetExpertById
{
    public sealed class GetExpertByIdQuery : IQuery<GetExpertByIdQueryResult>
    {
        public GetExpertByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
