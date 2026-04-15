using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public sealed class OrderCompletedSmsHandler : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
