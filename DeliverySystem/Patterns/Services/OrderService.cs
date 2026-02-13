using DeliverySystem.Models;
using DeliverySystem.Patterns.Builders;
using DeliverySystem.Patterns.Strategies;

namespace DeliverySystem.Patterns.Services
{
    public class OrderService
    {
        private List<Order> _orders;
        private int _nextOrderId;

        public OrderService()
        {
            _orders = new List<Order>();
            _nextOrderId = 1;
        }

        public Order CreateOrder(IOrderBuilder builder, string customerName, string address)
        {
            builder.SetCustomerInfo(customerName, address);

            var order = builder.Build();
            order.Id = _nextOrderId++;


            _orders.Add(order);
            return order;
        }

        public void ChangePricingStrategy(int orderId, IPricingStrategy newStrategy)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order == null) return;

            order.PricingStrategy = newStrategy;
            order.CalculateTotal();
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order == null) return;

            order.Process();
        }

        public void NextOrderState(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order == null) return;

            order.NextState();
        }

        public Order GetOrder(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order == null)
                throw new InvalidOperationException($"Заказ с ID {orderId} не найден");

            return order;
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>(_orders);
        }

        public Order AddExistingOrder(Order order)
        {
            order.Id = _nextOrderId++;
            _orders.Add(order);
            return order;
        }
    }
}

