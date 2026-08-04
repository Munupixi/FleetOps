using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class RoutePointConfiguration : IEntityTypeConfiguration<RoutePoint>
{
    public void Configure(EntityTypeBuilder<RoutePoint> builder)
    {
        _ = builder.ToTable("RoutePoints");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.RouteId).IsRequired();
        _ = builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        _ = builder.Property(x => x.Address).HasMaxLength(500).IsRequired();
        _ = builder.Property(x => x.OrderNumber).IsRequired();
        _ = builder.HasIndex(x => new { x.RouteId, x.OrderNumber }).IsUnique();
        _ = builder.HasOne(x => x.Route).WithMany(x => x.RoutePoints).HasForeignKey(x => x.RouteId).OnDelete(DeleteBehavior.NoAction);
    }
}
