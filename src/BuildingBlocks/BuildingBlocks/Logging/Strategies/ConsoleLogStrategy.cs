using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Logging.Strategies;

public sealed class ConsoleLogStrategy : IlogStrategy
{
    /// <summary>
    /// Log the message with the given logger and request object.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Log(ILogger logger, string message, object request)
    {
        logger.LogInformation("[Console] {Message}: {@Request}", message, request);
    }

    /// <summary>
    /// Log the message with the given logger and request object at the specified log level.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <param name="exception"></param>
    /// <param name="innerException"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void LogError(ILogger logger, string message, object request, Exception? exception = null, Exception? innerException = null)
    {
        logger.LogError(exception, "[Console] {Message}: {@Request}", message, request);
        if(exception != null)
        {
            logger.LogError(exception, "[Console] {Message}: {@Request}", message, request);
        }
        if (innerException != null)
        {
            logger.LogError(innerException, "[Console] {Message}: {@Request}", message, request);
        }
    }
}
