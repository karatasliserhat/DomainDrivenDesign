using DomainDrivenDesign.Domain.Orders;
using MediatR;
using orders = DomainDrivenDesign.Domain.Orders.Order;
namespace DomainDrivenDesign.Application.Features.Order.GetAll
{
    internal class GetAllOrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrderQuery, List<orders>>
    {
        public async Task<List<orders>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return await orderRepository.GetAllAsync(cancellationToken);
        }
    }
}
