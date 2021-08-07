using GeekTime.Infrastructure.Core;
using GeekTime.Ordering.Domain.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeekTime.Ordering.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<Order[]> GetAllAsync(CancellationToken cancellationToken);
    }
}
