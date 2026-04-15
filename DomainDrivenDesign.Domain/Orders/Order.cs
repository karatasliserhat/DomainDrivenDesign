using DomainDrivenDesign.Domain.Entities;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed partial class Order : Entity
    {
        public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum orderStatus) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedDate = createdDate;
            OrderStatus = orderStatus;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public OrderStatusEnum OrderStatus { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }




        public void CreateOrder(List<CreateOrderDto> createOrderDtos)
        {
            foreach (var item in createOrderDtos)
            {
                if (item.Quantity < 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                OrderLine orderLine = new(Guid.NewGuid(), Id, item.ProductId, item.Quantity, new(item.Amaount, item.Currency));

                OrderLines.Add(orderLine);
            }
        }

        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderLine = OrderLines.FirstOrDefault(ol => ol.Id == orderLineId);
            if (orderLine == null)
                throw new ArgumentException("Order line not found.");
            OrderLines.Remove(orderLine);
        }
    }
}
