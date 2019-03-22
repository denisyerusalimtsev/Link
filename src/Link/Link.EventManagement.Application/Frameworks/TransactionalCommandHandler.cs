using System.Threading.Tasks;
using System.Transactions;
using Link.EventManagement.Application.Frameworks.Events;

namespace Link.EventManagement.Application.Frameworks
{
    public abstract class TransactionalCommandHandler<T, TReply> : CommandHandler<T, TReply>
        where T : class, ICommand<TReply>
        where TReply : class, ICommandReply
    {
        private readonly IEventDispatcher _dispatcher;

        protected TransactionalCommandHandler(
            ICommandValidator<T, TReply> validator,
            IEventDispatcher dispatcher)
            : base(validator)
        {
            _dispatcher = dispatcher;
        }

        public sealed override async Task<TR> Handle<TR>(ICommand<TR> command)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                TR result = await base.Handle(command);

                await _dispatcher.Dispatch(DomainEvents);

                transactionScope.Complete();

                return result;
            }
        }
    }
}
