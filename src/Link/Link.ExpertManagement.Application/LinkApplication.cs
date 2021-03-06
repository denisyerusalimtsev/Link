﻿using Link.Common.Domain.Framework.Frameworks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Link.ExpertManagement.Application
{
    public sealed class LinkApplication : IApplication
    {
        private readonly IServiceProvider _provider;

        public LinkApplication(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> HandleCommand<TResult>(ICommand<TResult> command)
            where TResult : class, ICommandReply
        {
            var type = typeof(CommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult)).GetInterfaces().First();

            try
            {
                dynamic commandHandler = _provider.GetServices(type).First();
                return await commandHandler.Handle(command);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Command handler is not registered for given command. Command Type: [{command.GetType()}] ", ex);
            }
        }

        public async Task<TResult> RunQuery<TResult>(IQuery<TResult> query)
            where TResult : IQueryResult
        {
            var type = typeof(QueryRunner<,>).MakeGenericType(query.GetType(), typeof(TResult)).GetInterfaces().First();

            dynamic queryRunner = _provider.GetService(type);
            return await queryRunner.Run(query);
        }
    }
}
