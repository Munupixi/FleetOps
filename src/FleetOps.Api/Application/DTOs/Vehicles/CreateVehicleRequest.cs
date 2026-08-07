using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Application.DTOs.Vehicles;

public sealed record CreateVehicleRequest(
    string PlateNumber,
    string Vin,
    string Brand,
    string Model,
    int Year,
    int Mileage,
    FuelType FuelType
);