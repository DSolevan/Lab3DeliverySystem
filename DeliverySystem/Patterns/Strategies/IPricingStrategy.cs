using DeliverySystem.Models;

namespace DeliverySystem.Patterns.Strategies
{
    public interface IPricingStrategy
    {
        void CalculatePrice(Order order);
    }
}
