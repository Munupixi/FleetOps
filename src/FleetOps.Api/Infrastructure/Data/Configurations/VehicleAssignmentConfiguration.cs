using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class VehicleAssignmentConfiguration : IEntityTypeConfiguration<VehicleAssignment>
{
    public void Configure(EntityTypeBuilder<VehicleAssignment> builder)
    {
        _ = builder.ToTable("VehicleAssignments");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.VehicleId).IsRequired();
        _ = builder.Property(x => x.DriverId).IsRequired();
        _ = builder.Property(x => x.AssignedAt).IsRequired();
        _ = builder.HasIndex(x => new { x.VehicleId, x.UnassignedAt }).IsUnique()
            .HasFilter("[UnassignedAt] IS NULL");
        _ = builder.HasIndex(x => x.DriverId);
        _ = builder.HasOne(x => x.Vehicle).WithMany(x => x.VehicleAssignments)
            .HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
        _ = builder.HasOne(x => x.Driver).WithMany(x => x.VehicleAssignments)
            .HasForeignKey(x => x.DriverId).OnDelete(DeleteBehavior.NoAction);
    }
}
