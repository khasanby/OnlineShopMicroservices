using MediatR;

namespace BuildingBlocks.CQRS.Commands;

/// <summary>
/// The command interface. In case we don't need a response, we can use the <see cref="Unit"/> type.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// The command interface. Marker interface for commands.
/// </summary>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}