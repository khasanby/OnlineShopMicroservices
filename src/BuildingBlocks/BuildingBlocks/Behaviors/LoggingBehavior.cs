using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace BuildingBlocks.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;
    private readonly BuildingBlocks.Logging.Factory.LogStrategyFactory _strategyFactory;

    public LoggingBehavior(BuildingBlocks.Logging.Factory.LogStrategyFactory strategyFactory)
    {
        _strategyFactory = strategyFactory;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var attr = request.GetType().GetCustomAttribute<BuildingBlocks.Logging.Attributes.LogBehaviorAttribute>();
        if (attr is not null)
        {
            var strategy = _strategyFactory.Get(attr.logType);
            strategy.Log(_logger, "Handling request", request);
        }

        return await next();
    }
}