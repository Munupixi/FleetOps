namespace FleetOps.Api.Domain.Entities;

public class Role
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();
}
