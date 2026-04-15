using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed partial class Order
    {
        public sealed record CreateOrderDto(Guid ProductId, int Quantity, decimal Amaount, Currency Currency);
    }
}
