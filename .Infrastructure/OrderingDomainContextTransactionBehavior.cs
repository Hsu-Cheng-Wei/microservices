using GeekTime.Infrastructure.Core.Behaviors;
using Microsoft.Extensions.Logging;

namespace GeekTime.Infrastructure
{
    public class OrderingDomainContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<OrderingDomainContext, TRequest, TResponse>
    {
        public OrderingDomainContextTransactionBehavior(OrderingDomainContext dbContext, ILogger<OrderingDomainContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger) { }
    }
}
