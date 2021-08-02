using GeekTime.Ordering.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekTime.Ordering.Infrastructure.EntityConfigurations
{
    internal class OrderEntityTypeConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("order");

            builder.Property(p => p.UserName).HasMaxLength(20);

            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
                a.Property(p => p.City).HasMaxLength(20);
                a.Property(p => p.Street).HasMaxLength(50);
                a.Property(p => p.ZipCode).HasMaxLength(10);
            });
        }
    }
}
