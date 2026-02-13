using DeliverySystem.Models;
using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.States;
using DeliverySystem.Patterns.Strategies;

namespace DeliverySystem.Patterns.Builders
{
    public class ExpressOrderBuilder : IOrderBuilder
    {

        private Order _order;

        public ExpressOrderBuilder()
        {
            _order = new Order();
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
            _order.Type = OrderType.Express;
            _order.PricingStrategy = new ExpressPricingStrategy();
            _order.CurrentState = new PreparingState();
        }

        public Order Build()
        {
            _order.CalculateTotal();
            return _order;
        }

    }
}
