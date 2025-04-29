using Coupon.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<CouponDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CouponDbConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();