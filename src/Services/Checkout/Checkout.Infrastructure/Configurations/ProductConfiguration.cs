using Checkout.Domain.Entities;
using Checkout.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checkout.Infrastructure.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<ProductDB>
{
    public void Configure(EntityTypeBuilder<ProductDB> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                        productId => productId.Value,
                        dbId => ProductId.Of(dbId));

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}