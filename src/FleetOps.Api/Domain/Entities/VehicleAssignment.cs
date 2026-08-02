namespace FleetOps.Api.Domain.Entities;

public class VehicleAssignment
{
    public Guid Id { get; init; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public Guid DriverId { get; set; }
    public Driver Driver { get; set; } = null!;

    public DateTime AssignedAt { get; set; }
    public DateTime? UnassignedAt { get; set; }
}
