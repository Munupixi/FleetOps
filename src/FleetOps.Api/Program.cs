using FleetOps.Api.Application.DTOs.Vehicles;
using FleetOps.Api.Application.Interfaces;
using FleetOps.Api.Application.Services;
using FleetOps.Api.Application.Validators.Vehicles;
using FleetOps.Api.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IValidator<CreateVehicleRequest>, CreateVehicleRequestValidator>();

builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddDbContext<FleetOpsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();