using FleetOps.Api.Domain.Entities;
using FleetOps.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        _ = builder.ToTable("Maintenances");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.VehicleId).IsRequired();
        _ = builder.Property(x => x.MaintenanceTypeId).IsRequired();
        _ = builder.Property(x => x.PlannedDate).IsRequired();
        _ = builder.Property(x => x.Status)
            .HasDefaultValue(MaintenanceStatus.Planned)
            .HasSentinel((MaintenanceStatus)0)
            .IsRequired();
        _ = builder.HasIndex(x => new { x.VehicleId, x.PlannedDate });
        _ = builder.HasIndex(x => x.MaintenanceTypeId);
        _ = builder.HasOne(x => x.Vehicle).WithMany(x => x.Maintenances)
            .HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
        _ = builder.HasOne(x => x.MaintenanceType).WithMany(x => x.Maintenances)
            .HasForeignKey(x => x.MaintenanceTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}
