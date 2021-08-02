using System.Threading.Tasks;

namespace GeekTime.Ordering.API.IntegrationEvents
{
    public interface ISubscriberService
    {
        Task OrderCreated(OrderCreatedIntegrationEvent @event);
    }
}
