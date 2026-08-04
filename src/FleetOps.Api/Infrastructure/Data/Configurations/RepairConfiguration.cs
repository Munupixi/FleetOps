using FleetOps.Api.Domain.Entities;
using FleetOps.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class RepairConfiguration : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        _ = builder.ToTable("Repairs");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.VehicleId).IsRequired();
        _ = builder.Property(x => x.RepairTypeId).IsRequired();
        _ = builder.Property(x => x.Description).IsRequired();
        _ = builder.Property(x => x.Cost).HasPrecision(10, 2).IsRequired();
        _ = builder.Property(x => x.Status).HasDefaultValue(RepairStatus.Registered).HasSentinel((RepairStatus)0).IsRequired();
        _ = builder.Property(x => x.CreatedAt).IsRequired();
        _ = builder.HasIndex(x => new { x.VehicleId, x.CreatedAt });
        _ = builder.HasIndex(x => x.RepairTypeId);
        _ = builder.HasOne(x => x.Vehicle).WithMany(x => x.Repairs)
            .HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
        _ = builder.HasOne(x => x.RepairType).WithMany(x => x.Repairs)
            .HasForeignKey(x => x.RepairTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}
