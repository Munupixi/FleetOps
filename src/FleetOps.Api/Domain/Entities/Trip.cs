using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class Trip
{
    public Guid Id { get; init; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public Guid DriverId { get; set; }
    public Driver Driver { get; set; } = null!;

    public Guid RouteId { get; set; }
    public Route Route { get; set; } = null!;

    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TripStatus Status { get; set; } = TripStatus.Planned;
}
