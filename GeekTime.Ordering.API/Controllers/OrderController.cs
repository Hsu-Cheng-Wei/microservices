using GeekTime.Ordering.API.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
