namespace FleetOps.Api.Domain.Entities;

public class MaintenanceType
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Maintenance> Maintenances { get; } = new List<Maintenance>();
}
