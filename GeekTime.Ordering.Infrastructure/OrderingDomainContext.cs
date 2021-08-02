using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using GeekTime.Ordering.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GeekTime.Infrastructure
{
    public class OrderingDomainContext : EFContext
    {
        public OrderingDomainContext(DbContextOptions options, IMediator mediator) : base(options, mediator) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurations());

            base.OnModelCreating(modelBuilder);
        }

    }
}
