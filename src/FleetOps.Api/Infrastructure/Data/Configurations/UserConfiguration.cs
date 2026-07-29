using FleetOps.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetOps.Api.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable("Users");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(x => x.LastName)
            .HasMaxLength(200);

        _ = builder.Property(x =>x.DateOfBirth)
            .IsRequired();

        _ = builder.Property(x => x.Email)
            .HasMaxLength(200)
            .IsRequired();

        _ = builder.HasIndex(x => x.Email)
            .IsUnique();

        _ = builder.Property(x => x.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.Property(x => x.RoleId)
            .IsRequired();

        _ = builder.HasOne(x => x.Role)
            .WithMany(x =>  x.Users)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
