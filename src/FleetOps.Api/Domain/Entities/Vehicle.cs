using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; init; }

    public string PlateNumber { get; set; } = string.Empty;
    public string Vin { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Mileage { get; set; }
    public FuelType FuelType { get; set; }
    public VehicleStatus Status { get; set; } = VehicleStatus.Active;
}
