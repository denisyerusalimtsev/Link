using System.Threading.Tasks;

namespace Link.EventManagement.Application.Frameworks
{
    public interface IApplication
    {
        /// <summary>
        /// Handles the command and returns command results.
        /// </summary>
        /// <typeparam name="TResult">The type of the command result.</typeparam>
        /// <param name="command">Command to handle.</param>
        /// <returns>
        /// The command processing results.
        /// </returns>
        Task<TResult> HandleCommand<TResult>(ICommand<TResult> command) where TResult : class, ICommandReply;

        /// <summary>
        /// Runs the query and returns query results.
        /// </summary>
        /// <typeparam name="TResult">The type of the query result.</typeparam>
        /// <param name="query">Query to run.</param>
        /// <returns>
        /// The query results.
        /// </returns>
        Task<TResult> RunQuery<TResult>(IQuery<TResult> query) where TResult : IQueryResult;
    }
}
