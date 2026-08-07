using FleetOps.Api.Application.DTOs.Vehicles;
using FleetOps.Api.Application.Interfaces;
using FleetOps.Api.Domain.Entities;
using FleetOps.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetOps.Api.Application.Services;

public sealed class VehicleService : IVehicleService
{
    private readonly FleetOpsDbContext _dbContext;

    public VehicleService(FleetOpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<VehicleResponse> CreateAsync(CreateVehicleRequest createVehicleRequest,
        CancellationToken cancellationToken = default)
    {
        string plateNumber = createVehicleRequest.PlateNumber.Trim().ToUpperInvariant();

        string vin = createVehicleRequest.Vin.Trim().ToUpperInvariant();

        bool plateNumberExists = await _dbContext.Vehicles.AnyAsync
            (v => v.PlateNumber == plateNumber, cancellationToken);
        if (plateNumberExists)
        {
            throw new InvalidOperationException(
                "Vehicle with this plate number already exists.");
        }

        bool vinExists = await _dbContext.Vehicles.AnyAsync(
            v => v.Vin == vin, cancellationToken);
        if (vinExists)
        {
            throw new InvalidOperationException(
                "Vehicle with this VIN already exists.");
        }

        Vehicle vehicle = new()
        {
            Id = Guid.NewGuid(),
            PlateNumber = plateNumber,
            Vin = vin,
            Brand = createVehicleRequest.Brand.Trim(),
            Model = createVehicleRequest.Model.Trim(),
            Year = createVehicleRequest.Year,
            Mileage = createVehicleRequest.Mileage,
            FuelType = createVehicleRequest.FuelType
        };

        _ = _dbContext.Vehicles.Add(vehicle);
        _ = await _dbContext.SaveChangesAsync(cancellationToken);

        return new VehicleResponse(
            vehicle.Id,
            vehicle.PlateNumber,
            vehicle.Vin,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Year,
            vehicle.Mileage,
            vehicle.FuelType,
            vehicle.Status);
    }
}
