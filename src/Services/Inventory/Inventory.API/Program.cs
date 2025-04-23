using BuildingBlocks.CQRS.Dispatcher;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("InventoryDb"));
}).UseLightweightSessions();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDispatcher, Dispatcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();