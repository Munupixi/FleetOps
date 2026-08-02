using Microsoft.EntityFrameworkCore;
using FleetOps.Api.Domain.Entities;

namespace FleetOps.Api.Infrastructure.Data;

public class FleetOpsDbContext : DbContext
{
    public FleetOpsDbContext(DbContextOptions<FleetOpsDbContext> options) : base(options)
    {

    }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<VehicleAssignment> VehicleAssignments => Set<VehicleAssignment>();
    public DbSet<FuelRecord> FuelRecords => Set<FuelRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FleetOpsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
