using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        _ = builder.ToTable("Drivers");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(x => x.UserId)
            .IsRequired();

        _ = builder.Property(x => x.DriverLicenseNumber)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.HasIndex(x => x.DriverLicenseNumber)
            .IsUnique();

        _ = builder.Property(x => x.DriverLicenseExpiryDate)
            .IsRequired();

        _ = builder.Property(x => x.HireDate)
            .IsRequired();

        _ = builder.Property(x => x.Status)
            .IsRequired();

        _ = builder.HasIndex(x => x.UserId)
            .IsUnique();

        _ = builder.HasOne(x => x.User)
            .WithOne(x => x.Driver)
            .HasForeignKey<Driver>(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
