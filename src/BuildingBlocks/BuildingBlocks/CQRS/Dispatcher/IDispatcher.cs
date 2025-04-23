using BuildingBlocks.CQRS.Commands;
using BuildingBlocks.CQRS.Queries;

namespace BuildingBlocks.CQRS.Dispatcher;

public interface IDispatcher
{
    /// <summary>
    /// Dispatches a command to the appropriate handler.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

    /// <summary>
    /// Dispatches a query to the appropriate handler.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}