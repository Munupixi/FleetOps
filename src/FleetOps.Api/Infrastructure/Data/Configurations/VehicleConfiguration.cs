using FleetOps.Api.Domain.Entities;
using FleetOps.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        _ = builder.ToTable("Vehicles");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(x => x.PlateNumber)
            .HasMaxLength(20)
            .IsRequired();

        _ = builder.HasIndex(x => x.PlateNumber)
            .IsUnique();

        _ = builder.Property(x => x.Vin)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.HasIndex(x => x.Vin)
            .IsUnique();

        _ = builder.Property(x => x.Brand)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(x => x.Model)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(x => x.Year)
            .IsRequired();

        _ = builder.Property(x => x.Mileage)
            .IsRequired();

        _ = builder.Property(x => x.FuelType)
            .IsRequired();

        _ = builder.Property(x => x.Status)
            .HasDefaultValue(VehicleStatus.Active)
            .IsRequired();
    }
}
