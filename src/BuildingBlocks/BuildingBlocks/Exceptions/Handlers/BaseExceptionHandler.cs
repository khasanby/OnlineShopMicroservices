using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handlers;

public class BaseExceptionHandler : IExceptionHandler
{
    private readonly ILogger<BaseExceptionHandler> _logger;

    public BaseExceptionHandler(ILogger<BaseExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not BaseException baseEx)
            return false;

        _logger.LogError(exception, "Handled BaseException: {ErrorCode}", baseEx.ErrorCode);

        context.Response.StatusCode = baseEx.StatusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            errorCode = baseEx.ErrorCode,
            message = baseEx.Message,
            status = baseEx.StatusCode,
            timestamp = DateTime.UtcNow
        };

        await context.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}