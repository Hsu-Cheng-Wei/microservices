using DotNetCore.CAP;
using GeekTime.Ordering.API.IntegrationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GeekTime.Ordering.API.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly ICapPublisher _capPublisher;

        public CreateOrderCommandHandler(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _capPublisher.Publish("order.log.created", new OrderCreatedIntegrationEvent
            {
                Count = request.Count
            });

            return Unit.Task;
        }
    }
}
