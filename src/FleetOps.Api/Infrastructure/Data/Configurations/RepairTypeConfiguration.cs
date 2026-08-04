using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class RepairTypeConfiguration : IEntityTypeConfiguration<RepairType>
{
    public void Configure(EntityTypeBuilder<RepairType> builder)
    {
        _ = builder.ToTable("RepairTypes");
        _ = builder.HasKey(x => x.Id);
        _ = builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        _ = builder.HasIndex(x => x.Name).IsUnique();
    }
}
