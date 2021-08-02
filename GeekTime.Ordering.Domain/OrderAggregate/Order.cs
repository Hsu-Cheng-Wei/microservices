using GeekTime.Domain.Abstractions;
using GeekTime.Domain.Events;
using System;

namespace GeekTime.Domain.OrderAggregate
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public string UserName { get; private set; }

        public Address Address { get; private set; }

        public int ItemCount { get; private set; }


        public Order() { }

        public Order(Guid userId, string userName, int itemCount, Address address)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            UserName = userName;
            Address = address;
            ItemCount = itemCount;

            this.AddDomainEvent(new OrderCreatedDomainEvents(this));
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }
    }
}
