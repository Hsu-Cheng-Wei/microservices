using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using System;

namespace GeekTime.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, Guid, DomainContext>, IOrderRepository
    {
        public OrderRepository(DomainContext context) : base(context) { }
    }
}
