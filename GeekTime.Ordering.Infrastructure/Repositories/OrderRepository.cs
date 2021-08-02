using GeekTime.Infrastructure;
using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using System;

namespace GeekTime.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, Guid, OrderingDomainContext>, IOrderRepository
    {
        public OrderRepository(OrderingDomainContext context) : base(context) { }
    }
}
