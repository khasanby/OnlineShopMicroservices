using BuildingBlocks.Abstractions.Commands;
using MediatR;

namespace BuildingBlocks.Abstractions.Handlers;

/// <summary>
/// The command handler interface. In case we don't need a response, we can use the <see cref="Unit"/> type.
/// </summary>
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}


/// <summary>
/// The command handler interface.
/// </summary>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}