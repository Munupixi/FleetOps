namespace FleetOps.Api.Domain.Entities;

public class Route
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<RoutePoint> RoutePoints { get; } = new List<RoutePoint>();
    public ICollection<Trip> Trips { get; } = new List<Trip>();
}
