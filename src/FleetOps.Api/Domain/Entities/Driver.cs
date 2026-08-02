using FleetOps.Api.Domain.Enums;

namespace FleetOps.Api.Domain.Entities;

public class Driver
{
    public Guid Id { get; init; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string DriverLicenseNumber { get; set; } = string.Empty;
    public DateOnly DriverLicenseExpiryDate { get; set; }
    public DateOnly HireDate { get; set; }
    public DriverStatus Status { get; set; }

    public ICollection<VehicleAssignment> VehicleAssignments { get; } = new List<VehicleAssignment>();
}
