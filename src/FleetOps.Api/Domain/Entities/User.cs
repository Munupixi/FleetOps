namespace FleetOps.Api.Domain.Entities;

public class User
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Enums.UserStatus Status { get; set; } = Enums.UserStatus.Active;

    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public Driver? Driver { get; set; }
}
