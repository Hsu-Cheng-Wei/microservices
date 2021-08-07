using GeekTime.Infrastructure;
using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeekTime.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, Guid, OrderingDomainContext>, IOrderRepository
    {
        public OrderRepository(OrderingDomainContext context) : base(context) { }

        public Task<Order[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return DbContext.Orders.ToArrayAsync(cancellationToken);
        }
    }
}
