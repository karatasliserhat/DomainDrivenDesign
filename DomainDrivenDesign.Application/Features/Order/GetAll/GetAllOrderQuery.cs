using MediatR;
using orders = DomainDrivenDesign.Domain.Orders.Order;
namespace DomainDrivenDesign.Application.Features.Order.GetAll
{
    public record GetAllOrderQuery:IRequest<List<orders>>;
}
