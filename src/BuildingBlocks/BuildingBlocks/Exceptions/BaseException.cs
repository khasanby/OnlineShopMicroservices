namespace BuildingBlocks.Exceptions;

public abstract class BaseException : Exception
{
    /// <summary>
    /// Gets error code of the exception.
    /// </summary>
    public virtual string ErrorCode { get; }

    /// <summary>
    /// Gets status code of the exception.
    /// </summary>
    public virtual int StatusCode { get; }

    protected BaseException() { }

    protected BaseException(string? message) : base(message)
    { }

    protected BaseException(string? message, Exception innerException)
        : base(message, innerException)
    { }
}