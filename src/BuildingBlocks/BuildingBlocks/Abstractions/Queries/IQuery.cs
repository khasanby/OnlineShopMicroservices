using MediatR;

namespace BuildingBlocks.Abstractions.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    // Marker interface for queries.
}