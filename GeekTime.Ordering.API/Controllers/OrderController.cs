using GeekTime.Ordering.API.Commands;
using GeekTime.Ordering.API.Queries;
using GeekTime.Ordering.Domain.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekTime.Ordering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{count}")]
        public void Create(int count)
        {
            _mediator.Send(new CreateOrderCommand(count), HttpContext.RequestAborted);
        }

        [HttpGet]
        public Task<Order[]> GetAll()
        {
            return _mediator.Send(new GetOrdersQueries(), HttpContext.RequestAborted);
        }
    }
}
