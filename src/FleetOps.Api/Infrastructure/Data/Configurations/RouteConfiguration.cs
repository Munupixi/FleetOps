using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteEntity = FleetOps.Api.Domain.Entities.Route;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<RouteEntity>
{
    public void Configure(EntityTypeBuilder<RouteEntity> builder)
    {
        _ = builder.ToTable("Routes");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        _ = builder.Property(x => x.Description).HasMaxLength(500);
        _ = builder.HasIndex(x => x.Name).IsUnique();
    }
}
