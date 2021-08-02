using DotNetCore.CAP;
using GeekTime.Ordering.Domain.OrderAggregate;
using GeekTime.Ordering.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace GeekTime.Ordering.API.IntegrationEvents
{
    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        private readonly IOrderRepository _repository;

        public SubscriberService(IOrderRepository repository)
        {
            _repository = repository;
        }

        [CapSubscribe("order.log.created")]
        public async Task OrderCreated(OrderCreatedIntegrationEvent @event)
        {
            var userId = Guid.Parse("3b1f515c-c26c-44bf-affb-cee1568e38cd");

            var order = new Order(userId, "James", @event.Count,
                new Address("rende", "Tainan", "717"));

            _repository.Add(order);

            await _repository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
