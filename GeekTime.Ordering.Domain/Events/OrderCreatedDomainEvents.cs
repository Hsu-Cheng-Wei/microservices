using GeekTime.Domain.Abstractions;
using GeekTime.Domain.OrderAggregate;

namespace GeekTime.Domain.Events
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
