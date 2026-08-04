using FleetOps.Api.Domain.Entities;
using FleetOps.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        _ = builder.ToTable("Trips");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.VehicleId).IsRequired();
        _ = builder.Property(x => x.DriverId).IsRequired();
        _ = builder.Property(x => x.RouteId).IsRequired();
        _ = builder.Property(x => x.StartTime).IsRequired();
        _ = builder.Property(x => x.Status).HasDefaultValue(TripStatus.Planned).HasSentinel((TripStatus)0).IsRequired();
        _ = builder.HasIndex(x => new { x.VehicleId, x.StartTime });
        _ = builder.HasIndex(x => new { x.DriverId, x.StartTime });
        _ = builder.HasIndex(x => x.RouteId);
        _ = builder.HasOne(x => x.Vehicle).WithMany(x => x.Trips)
            .HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
        _ = builder.HasOne(x => x.Driver).WithMany(x => x.Trips)
            .HasForeignKey(x => x.DriverId).OnDelete(DeleteBehavior.NoAction);
        _ = builder.HasOne(x => x.Route).WithMany(x => x.Trips)
            .HasForeignKey(x => x.RouteId).OnDelete(DeleteBehavior.NoAction);
    }
}
