using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using System;

namespace GeekTime.Ordering.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
