using DeliverySystem.Models;
using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.States;
using DeliverySystem.Patterns.Strategies;

namespace DeliverySystem.Patterns.Builders
{

    public class StandardOrderBuilder : IOrderBuilder
    {

        private Order _order = new Order();

        public StandardOrderBuilder()
        {
        }

        public void SetCustomerInfo(string name, string address)
        {
            _order.CustomerName = name;
            _order.Address = address;
        }

        public void AddItem(Dish dish, int quantity = 1)
        {
            _order.Items.Add(new OrderItem(dish, quantity));
        }

        public void SetOrderType(OrderType type)
        {
            _order.Type = type;

            _order.PricingStrategy = type switch
            {
                OrderType.Express => new ExpressPricingStrategy(),
                _ => new StandardPricingStrategy()
            };

            _order.CurrentState = new PreparingState();
        }

        public Order Build()
        {
            _order.CalculateTotal();
            return _order;
        }

    }
}

