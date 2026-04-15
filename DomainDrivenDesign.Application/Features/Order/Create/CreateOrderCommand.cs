using MediatR;
using static DomainDrivenDesign.Domain.Orders.Order;

namespace DomainDrivenDesign.Application.Features.Order.Create
{
    public record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos):IRequest;
    
}
