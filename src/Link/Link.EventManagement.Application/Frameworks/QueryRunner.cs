using System;
using System.Collections.Generic;
using System.Text;

namespace Link.EventManagement.Application.Frameworks
{
    using System.Threading.Tasks;

    namespace ColemanRG.ProjectsModule.Application.Framework
    {
        public abstract class QueryRunner<TQ, T> : IQueryRunner<T>
            where TQ : class, IQuery<T>
            where T : IQueryResult
        {
            public abstract Task<T> Run(TQ query);

            public Task<T> Run(IQuery<T> query)
            {
                return Run(query as TQ);
            }
        }
    }
}
