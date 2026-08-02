using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class FuelRecord
{
    public Guid Id { get; init; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public FuelType FuelType { get; set; }
    public decimal Volume { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public DateTime RefueledAt { get; set; }
}
