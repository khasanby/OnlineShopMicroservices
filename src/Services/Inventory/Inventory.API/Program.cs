using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("InventoryDb"));
}).UseLightweightSessions();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDispatcher, Dispatcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, title, errorCode) = exception switch
        {
            BaseException ex => (ex.StatusCode, ex.Message, ex.ErrorCode),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.", "Server.Error")
        };

        context.Response.StatusCode = statusCode;

        var problem = new
        {
            status = statusCode,
            title = title,
            errorCode = errorCode,
            timestamp = DateTime.UtcNow
        };

        await context.Response.WriteAsJsonAsync(problem);
    });
});


app.Run();