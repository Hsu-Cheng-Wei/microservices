using GeekTime.Ordering.Domain.OrderAggregate;
using MediatR;

namespace GeekTime.Ordering.API.Queries
{
    public class GetOrdersQueries : IRequest<Order[]>
    {
    }
}
