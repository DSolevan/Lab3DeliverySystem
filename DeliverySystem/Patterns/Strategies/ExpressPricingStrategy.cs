using DeliverySystem.Models;

namespace DeliverySystem.Patterns.Strategies
{
    public class ExpressPricingStrategy : IPricingStrategy
    {
        public void CalculatePrice(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            const decimal taxRate = 0.10m;
            const decimal expressDeliveryFee = 10.0m; 
            const decimal expressMultiplier = 1.15m; 

            order.Tax = order.Subtotal * taxRate;
            order.DeliveryFee = expressDeliveryFee;

            var subtotalWithExpress = order.Subtotal * expressMultiplier;
            order.Total = subtotalWithExpress + order.Tax + order.DeliveryFee;
        }
    }
}

