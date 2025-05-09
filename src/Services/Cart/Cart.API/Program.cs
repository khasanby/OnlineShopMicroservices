using BuildingBlocks.Behaviors;
using Cart.Application.DataAccess;
using Cart.Application.Decorators;
using Cart.Domain.Data;
using Cart.Domain.Entities;
using Coupon.Grpc;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Application Services.
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// Data Services.
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.Username);
}).UseLightweightSessions();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.Decorate<ICartRepository, CacheCartRepositoryDecorator>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("CacheDb")!;
    options.InstanceName = "CartCache";
});

// GRPC Services.
builder.Services.AddGrpcClient<CouponProtoService.CouponProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcServices:CouponUrl"]);
});

// Healhchecks.
builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("CartDb")!)
                .AddNpgSql(builder.Configuration.GetConnectionString("CacheDb")!);

// Manually register the cache decorator.
//builder.Services.AddScoped<ICartRepository>(provider =>
//{
//    CartRepository cartRepository = provider.GetRequiredService<CartRepository>();
//    IDistributedCache cache = provider.GetRequiredService<IDistributedCache>();

//    return new CacheCartRepositoryDecorator(cartRepository, cache);
//});

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("CartDb")!);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();