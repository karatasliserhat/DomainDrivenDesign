using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public  sealed record OrderDomainEvent(Order Order):INotification;
}
