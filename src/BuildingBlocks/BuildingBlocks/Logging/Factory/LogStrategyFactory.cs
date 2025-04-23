using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Logging.Factory;

public sealed class LogStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public LogStrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Strategies.IlogStrategy Get(Enums.LoggingType type) =>
        type switch
        {
            Enums.LoggingType.Console => _serviceProvider.GetRequiredService<Strategies.ConsoleLogStrategy>(),
            Enums.LoggingType.File => _serviceProvider.GetRequiredService<Strategies.FileLogStrategy>(),
            Enums.LoggingType.Database => _serviceProvider.GetRequiredService<Strategies.DatabaseLogStrategy>(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}