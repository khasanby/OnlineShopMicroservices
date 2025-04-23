using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Logging.Strategies;

public interface IlogStrategy
{
    /// <summary>
    /// Log the message with the given logger and request object.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    public void Log(ILogger logger, string message, object request);

    /// <summary>
    /// Log the message with the given logger and request object at the specified log level.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <param name="exception"></param>
    public void LogError(ILogger logger,
                         string message,
                         object request,
                         Exception? exception = null,
                         Exception? innerException = null);
}