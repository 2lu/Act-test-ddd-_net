using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id);

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
        .HasMaxLength(20);
    }
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.CustomerId).IsRequired().HasMaxLength(100);
        builder.Property(e => e.TotalSaleAmount).IsRequired();
        builder.Property(e => e.Branch).IsRequired().HasMaxLength(100);
        builder.Property(e => e.IsCancelled).IsRequired();

    }
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {

        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductId).IsRequired();
        builder.Property(e => e.Quantity).IsRequired();
        builder.Property(e => e.UnitPrice).IsRequired();
        builder.Property(e => e.Discount).IsRequired();

    }

}
