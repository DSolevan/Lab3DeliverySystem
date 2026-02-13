using DeliverySystem.Models;

namespace DeliverySystem.Patterns.Strategies
{
    public class DiscountPricingStrategy : IPricingStrategy
    {
        private decimal _discountPercentage;

        public DiscountPricingStrategy(decimal discountPercentage = 0.1m) 
        {
            _discountPercentage = discountPercentage;
        }

        public void CalculatePrice(Order order)
        {
            const decimal taxRate = 0.10m;
            const decimal deliveryFee = 5.0m;

            var discountAmount = order.Subtotal * _discountPercentage;
            var discountedSubtotal = order.Subtotal - discountAmount;

            order.Tax = discountedSubtotal * taxRate;
            order.DeliveryFee = deliveryFee;
            order.Total = discountedSubtotal + order.Tax + order.DeliveryFee;
        }
    }
}