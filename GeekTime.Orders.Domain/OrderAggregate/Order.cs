using GeekTime.Domain.Abstractions;
using System;

namespace GeekTime.Ordering.Domain.OrderAggregate
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public string UserName { get; private set; }

        public Address Address { get; private set; }

        public int ItemCount { get; private set; }

        public DateTime CreateTime { get; }


        public Order() { }

        public Order(Guid userId, string userName, int itemCount, Address address)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
            UserId = userId;
            UserName = userName;
            Address = address;
            ItemCount = itemCount;
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }
    }
}
