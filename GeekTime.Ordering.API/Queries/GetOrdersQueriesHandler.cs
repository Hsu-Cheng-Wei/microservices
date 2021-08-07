using GeekTime.Ordering.Domain.OrderAggregate;
using GeekTime.Ordering.Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace GeekTime.Ordering.API.Queries
{
    public class GetOrdersQueriesHandler : IRequestHandler<GetOrdersQueries, Order[]>
    {
        private readonly IOrderRepository _repository;

        public GetOrdersQueriesHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task<Order[]> Handle(GetOrdersQueries request, CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync(cancellationToken);
        }
    }
}
