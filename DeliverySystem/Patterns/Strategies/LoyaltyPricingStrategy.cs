using DeliverySystem.Models;

namespace DeliverySystem.Patterns.Strategies
{
    public class LoyaltyPricingStrategy : IPricingStrategy
    {
        private int _loyaltyPoints;

        public LoyaltyPricingStrategy(int loyaltyPoints)
        {
            _loyaltyPoints = loyaltyPoints;
        }

        public void CalculatePrice(Order order)
        {
            const decimal taxRate = 0.10m;
            const decimal deliveryFee = 5.0m;

            var pointsDiscount = _loyaltyPoints * 0.01m;
            var maxDiscount = order.Subtotal * 0.2m; 
            var actualDiscount = pointsDiscount > maxDiscount ? maxDiscount : pointsDiscount;

            var discountedSubtotal = order.Subtotal - actualDiscount;

            order.Tax = discountedSubtotal * taxRate;
            order.DeliveryFee = deliveryFee;
            order.Total = discountedSubtotal + order.Tax + order.DeliveryFee;
        }
    }
}
