using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class Maintenance
{
    public Guid Id { get; init; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public Guid MaintenanceTypeId { get; set; }
    public MaintenanceType MaintenanceType { get; set; } = null!;

    public DateOnly PlannedDate { get; set; }
    public DateOnly? CompletedDate { get; set; }
    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Planned;
}
