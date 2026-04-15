using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public  sealed record OrderDomainEvent(Guid OrderId):INotification;
}
