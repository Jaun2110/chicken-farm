using ChickenFarm.Application.Interfaces;
using ChickenFarm.Application.Services;
using ChickenFarm.Infrastructure.Data;
using ChickenFarm.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IFlockRepository, FlockRepository>();
builder.Services.AddScoped<IEggRepository, EggRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaddockRepository, PaddockRepository>();

// Services
builder.Services.AddScoped<FlockService>();
builder.Services.AddScoped<EggService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<PaddockService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddSingleton<FeedCalculatorService>();

// CORS (for Angular dev server)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto-apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();