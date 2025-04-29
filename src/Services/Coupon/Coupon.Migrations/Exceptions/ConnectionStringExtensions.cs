namespace Coupon.Migrations.Exceptions;

public static class ConnectionStringExtensions
{
    /// <summary>
    /// Extension method to throw an ArgumentNullException if the connection string is null or empty.
    /// </summary>
    public static string ThrowArgumentNullExceptionIfConnectionStringIsNullOrEmpty(this string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
        }

        return connectionString;
    }
}