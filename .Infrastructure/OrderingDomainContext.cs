using GeekTime.Domain.OrderAggregate;
using GeekTime.Infrastructure.Core;
using GeekTime.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GeekTime.Infrastructure
{
    public class OrderingDomainContext : EFContext
    {
        public OrderingDomainContext(DbContextOptions options, IMediator mediator) : base(options, mediator) { }

        public DbSet<Order> Orders { get; set; }

        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfigurations());

            base.OnModelCreating(modelBuilder);
        }

    }
}
