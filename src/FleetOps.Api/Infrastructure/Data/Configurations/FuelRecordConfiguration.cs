using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class FuelRecordConfiguration : IEntityTypeConfiguration<FuelRecord>
{
    public void Configure(EntityTypeBuilder<FuelRecord> builder)
    {
        _ = builder.ToTable("FuelRecords");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.VehicleId).IsRequired();
        _ = builder.Property(x => x.FuelType).IsRequired();
        _ = builder.Property(x => x.Volume).HasPrecision(10, 2).IsRequired();
        _ = builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();
        _ = builder.Property(x => x.Mileage).IsRequired();
        _ = builder.Property(x => x.RefueledAt).IsRequired();
        _ = builder.HasIndex(x => new { x.VehicleId, x.RefueledAt });
        _ = builder.HasOne(x => x.Vehicle).WithMany(x => x.FuelRecords).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
    }
}
