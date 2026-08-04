namespace FleetOps.Api.Domain.Entities;

public class RepairType
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Repair> Repairs { get; } = new List<Repair>();
}
