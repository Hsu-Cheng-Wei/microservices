using MediatR;
using System;

namespace GeekTime.Ordering.API.Commands
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int Count { get; }

        public CreateOrderCommand(int count)
        {
            Count = count;
        }
    }
}
