using BuildingBlocks.CQRS.Commands;
using BuildingBlocks.CQRS.Queries;
using MediatR;

namespace BuildingBlocks.CQRS.Dispatcher;

public sealed class Dispatcher : IDispatcher
{
    private readonly IMediator _mediator;

    public Dispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Sends a command to the appropriate handler and returns the response.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        => _mediator.Send(command, cancellationToken);

    /// <summary>
    /// Sends a query to the appropriate handler and returns the response.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
     => _mediator.Send(query, cancellationToken);
}