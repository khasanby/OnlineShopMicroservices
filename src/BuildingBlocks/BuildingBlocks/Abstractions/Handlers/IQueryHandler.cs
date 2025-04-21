using BuildingBlocks.Abstractions.Queries;
using MediatR;

namespace BuildingBlocks.Abstractions.Handlers;

/// <summary>
/// The query handler interface. In case we don't need a response, we can use the <see cref="Unit"/> type.
/// </summary>
public interface IQueryHandler<in TQuery> : IQueryHandler<TQuery, Unit>
    where TQuery : IQuery<Unit>
{
}

/// <summary>
/// The query handler interface.
/// </summary>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}