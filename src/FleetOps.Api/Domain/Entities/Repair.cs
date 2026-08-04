using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class Repair
{
    public Guid Id { get; init; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public Guid RepairTypeId { get; set; }
    public RepairType RepairType { get; set; } = null!;

    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public RepairStatus Status { get; set; } = RepairStatus.Registered;
    public DateTime CreatedAt { get; set; }
}
