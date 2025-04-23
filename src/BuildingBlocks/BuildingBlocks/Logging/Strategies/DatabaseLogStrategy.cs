using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Logging.Strategies;

public sealed class DatabaseLogStrategy : IlogStrategy
{
    /// <summary>
    /// Log the message with the given logger and request object.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    public void Log(ILogger logger, string message, object request)
    {
        logger.LogInformation("[Database] [Info] {Message} | Payload: {@Request}", message, request);
        // TODO: insert into Logs (info) table
    }

    /// <summary>
    /// Log the message with the given logger and request object at the specified log level.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <param name="exception"></param>
    /// <param name="innerException"></param>
    public void LogError(ILogger logger, string message, object request, Exception? exception = null, Exception? innerException = null)
    {
        logger.LogError(exception, "[Database] [Error] {Message} | Payload: {@Request}", message, request);
        logger.LogError(innerException, "[Database] [InnerError] {Message} | Payload: {@Request}", message, request);
        // TODO: insert into Logs (errors) table
    }
}