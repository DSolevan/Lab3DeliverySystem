using DeliverySystem.Models;
using DeliverySystem.Patterns.Builders;

namespace DeliverySystem.Patterns.Factories
{
    public interface IOrderFactory
    {
        IOrderBuilder CreateOrderBuilder();
        Order CreateStandardOrder(string customerName, string address);
        Order CreateExpressOrder(string customerName, string address);
        Order CreatePremiumOrder(string customerName, string address);
    }
}

