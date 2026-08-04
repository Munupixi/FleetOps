namespace FleetOps.Api.Domain.Entities;

public class RoutePoint
{
    public Guid Id { get; init; }

    public Guid RouteId { get; set; }
    public Route Route { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int OrderNumber { get; set; }
}
