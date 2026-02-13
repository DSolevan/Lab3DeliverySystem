using DeliverySystem.Models;

namespace DeliverySystem.Patterns.Strategies
{
    public class StandardPricingStrategy : IPricingStrategy
    {
        public void CalculatePrice(Order order)
        {
            const decimal taxRate = 0.10m; 
            const decimal deliveryFee = 5.0m;

            order.Tax = order.Subtotal * taxRate;
            order.DeliveryFee = deliveryFee;
            order.Total = order.Subtotal + order.Tax + order.DeliveryFee;
        }
    }
}

