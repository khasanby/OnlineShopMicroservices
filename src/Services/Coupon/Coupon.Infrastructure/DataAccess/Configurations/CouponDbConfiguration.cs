using Coupon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coupon.Infrastructure.DataAccess.Configurations;

public sealed class CouponDbConfiguration : IEntityTypeConfiguration<CouponDb>
{
    public void Configure(EntityTypeBuilder<CouponDb> builder)
    {
        // Table name
        builder.ToTable("Coupons");

        // Primary key
        builder.HasKey(c => c.Id);

        // Property configurations
        builder.Property(c => c.Id)
               .HasDefaultValueSql("uuid_generate_v4()");

        builder.Property(c => c.ProductName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(c => c.Amount)
               .IsRequired();

        builder.HasIndex(c => c.ProductName)
               .IsUnique()
               .HasDatabaseName("IX_Coupons_ProductName");
    }
}