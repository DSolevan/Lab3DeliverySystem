using DeliverySystem.Models;
using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.Builders;

namespace DeliverySystem.Patterns.Factories
{
    public class ExpressOrderFactory : IOrderFactory
    {
        public IOrderBuilder CreateOrderBuilder()
        {
            return new ExpressOrderBuilder();
        }

        public Order CreateStandardOrder(string customerName, string address)
        {
            return CreateExpressOrder(customerName, address);
        }

        public Order CreateExpressOrder(string customerName, string address)
        {
            var builder = CreateOrderBuilder();
            builder.SetCustomerInfo(customerName, address);
            builder.SetOrderType(OrderType.Express);
            return builder.Build();
        }

        public Order CreatePremiumOrder(string customerName, string address)
        {
            var builder = CreateOrderBuilder();
            builder.SetCustomerInfo(customerName, address);
            builder.SetOrderType(OrderType.Express);
            return builder.Build();
        }
    }
}