using Checkout.Infrastructure.DataAccess;
using Checkout.Migrations.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Checkout.Migrations;

internal sealed class CheckoutDbContextFactory : IDesignTimeDbContextFactory<CheckoutDbContext>
{
    /// <summary>
    /// This method is used by the design-time tools to create an instance of the DbContext.
    /// </summary>
    public CheckoutDbContext CreateDbContext(string[] args)
    {
        string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        string coupondDbConnectionString = configuration.GetConnectionString("CouponDbConnectionString")
            .ThrowArgumentNullExceptionIfConnectionStringIsNullOrEmpty();

        var optionsBuilder = new DbContextOptionsBuilder<CheckoutDbContext>();
        optionsBuilder.UseSqlServer(coupondDbConnectionString, sqlOptions =>
        {
            //sqlOptions.EnableRetryOnFailure(
            //    maxRetryCount: 5,
            //    maxRetryDelay: TimeSpan.FromSeconds(30),
            //    errorNumbersToAdd: null);
        });

        return new CheckoutDbContext(optionsBuilder.Options);
    }
}