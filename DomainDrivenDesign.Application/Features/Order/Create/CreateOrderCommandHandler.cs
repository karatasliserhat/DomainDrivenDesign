using DomainDrivenDesign.Domain.Entities;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Order.Create
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<CreateOrderCommand>
    {
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.CreateAsync(request.CreateOrderDtos,cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);
    
             await mediator.Publish(new OrderDomainEvent(order), cancellationToken);
        }
    }
}
