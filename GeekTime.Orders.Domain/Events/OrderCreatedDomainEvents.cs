using GeekTime.Domain.Abstractions;
using GeekTime.Ordering.Domain.OrderAggregate;

namespace GeekTime.Ordering.Domain.Events
{
    public class OrderCreatedDomainEvents : IDomainEvent
    {
        public Order Order { get; }

        public OrderCreatedDomainEvents(Order order)
        {
            Order = order;
        }
    }
}
