using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal class OrderRepository(AppDbContext appDbContext) : IOrderRepository
    {
        public async Task<Order> CreateAsync(List<Order.CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {

            var order = new Order(Guid.NewGuid(), "1", DateTime.Now, OrderStatusEnum.AwaitinApproval);

            order.CreateOrder(createOrderDtos);

            await appDbContext.AddRangeAsync(order, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);

            return order;
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await appDbContext.Orders.ToListAsync(cancellationToken);
        }
    }
}
