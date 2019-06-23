using Autofac;
using Link.Common.Domain.Framework.Frameworks;
using System;
using System.Threading.Tasks;

namespace Link.IoT.Application
{
    public sealed class LinkApplication : IApplication
    {
        private readonly IServiceProvider _provider;
        private readonly IComponentContext _componentContext;

        public LinkApplication(
            IServiceProvider provider, 
            IComponentContext componentContext)
        {
            _provider = provider;
            _componentContext = componentContext;
        }

        public async Task<TReply> HandleCommand<TReply>(ICommand<TReply> command)
            where TReply : class, ICommandReply
        {
            var type = typeof(CommandHandler<,>).MakeGenericType(command.GetType(), typeof(TReply));

            try
            {
                dynamic commandHandler = _componentContext.Resolve(type);
                return await commandHandler.Handle(command);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Command handler is not registered for given command. Command ExpertType: [{command.GetType()}] ", ex);
            }
        }

        public async Task<TResult> RunQuery<TResult>(IQuery<TResult> query)
            where TResult : IQueryResult
        {
            var type = typeof(QueryRunner<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic queryRunner = _componentContext.Resolve(type);
            return await queryRunner.Run(query);
        }
    }
}
