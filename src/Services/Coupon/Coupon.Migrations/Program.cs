using Microsoft.EntityFrameworkCore;

namespace Coupon.Migrations;

internal sealed class Program
{
    internal static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Started Migrating to Coupon Database");
            var couponDbContextFactory = new CouponDbContextFactory();
            using var context = couponDbContextFactory.CreateDbContext(args);
            await context.Database.MigrateAsync();
            Console.WriteLine("Coupon Database Migration Completed");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while migrating the Coupon database: " + ex.Message);
            throw;
        }
        finally
        {
            Console.WriteLine("Finished Migrating to Coupon Database");
            Console.ReadKey();
        }
    }
}