using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Logging.Strategies;

public sealed class FileLogStrategy : IlogStrategy
{
    private readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

    /// <summary>
    /// Log the message with the given logger and request object.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="message"></param>
    /// <param name="request"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Log(ILogger logger, string message, object request)
    {
        File.AppendAllText(_logFilePath, $"[INFO] {DateTime.UtcNow}: {message} - {System.Text.Json.JsonSerializer.Serialize(request)}{Environment.NewLine}");
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
        File.AppendAllText(_logFilePath, $"[ERROR] {DateTime.UtcNow}: {message} - {System.Text.Json.JsonSerializer.Serialize(request)}{Environment.NewLine}");
        if (exception != null)
        {
            File.AppendAllText(_logFilePath, $"Exception: {exception.Message}{Environment.NewLine}");
        }
        if (innerException != null)
        {
            File.AppendAllText(_logFilePath, $"Inner Exception: {innerException.Message}{Environment.NewLine}");
        }
    }
}
