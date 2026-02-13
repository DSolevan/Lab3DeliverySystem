using DeliverySystem.Models;
using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.Builders;
using DeliverySystem.Patterns.Factories;
using DeliverySystem.Patterns.Services;
using DeliverySystem.Patterns.Strategies;

namespace DeliverySystem.Patterns.Facades
{
    public class DeliveryFacade
    {
        private  OrderService _orderService;
        private  MenuService _menuService;

        public DeliveryFacade()
        {
            _orderService = new OrderService();
            _menuService = new MenuService();
        }

        public List<Dish> GetMenu()
        {
            return _menuService.GetMenu();
        }

        public void AddDish(Dish dish)
        {
            _menuService.AddDish(dish);
        }

        public Dish GetDishById(int id)
        {
            return _menuService.GetDishById(id);
        }

        public Order CreateStandardOrder(string customerName, string address, List<(int dishId, int quantity)> items)
        {
            var factory = new StandardOrderFactory();
            var builder = factory.CreateOrderBuilder();

            return CreateOrderInternal(builder, customerName, address, OrderType.Standard, items);
        }

        public Order CreateExpressOrder(string customerName, string address, List<(int dishId, int quantity)> items)
        {
            var factory = new ExpressOrderFactory();
            var builder = factory.CreateOrderBuilder();

            return CreateOrderInternal(builder, customerName, address, OrderType.Express, items);
        }

        public Order GetOrder(int orderId)
        {
            return _orderService.GetOrder(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        public void NextState(int orderId)
        {
            _orderService.NextOrderState(orderId);
        }

        public void PreviousState(int orderId)
        {
            var order = _orderService.GetOrder(orderId);
            order.PreviousState();
        }

        public void ChangePricingStrategy(int orderId, IPricingStrategy newStrategy)
        {
            _orderService.ChangePricingStrategy(orderId, newStrategy);
        }

        private Order CreateOrderInternal(
            IOrderBuilder builder,
            string customerName,
            string address,
            OrderType type,
            List<(int dishId, int quantity)> items)
        {
            builder.SetCustomerInfo(customerName, address);
            builder.SetOrderType(type);

            foreach (var (dishId, quantity) in items)
            {
                var dish = _menuService.GetDishById(dishId);
                builder.AddItem(dish, quantity);
            }

            var order = builder.Build();

            return _orderService.AddExistingOrder(order);
        }
    }
}

