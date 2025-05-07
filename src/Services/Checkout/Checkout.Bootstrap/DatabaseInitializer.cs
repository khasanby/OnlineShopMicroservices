namespace Checkout.Bootstrap;

public static class DatabaseInitializer
{
    //public static async Task WarmUpDatabaseAsync(this WebApplication app)
    //{
    //    using var scope = app.Services.CreateScope();
    //    var services = scope.ServiceProvider;

    //    try
    //    {
    //        var dbContext = services.GetRequiredService<YourDbContext>();

    //        // Apply migrations
    //        await dbContext.Database.MigrateAsync();

    //        // Optional: seed data
    //        if (!await dbContext.Orders.AnyAsync()) // example
    //        {
    //            dbContext.Orders.Add(new Order { /*...*/ });
    //            await dbContext.SaveChangesAsync();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log or rethrow as needed
    //        var logger = services.GetRequiredService<ILogger<Program>>();
    //        logger.LogError(ex, "An error occurred while warming up the database.");
    //        throw;
    //    }
    //}
}