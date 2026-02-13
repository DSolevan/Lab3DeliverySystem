using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.States;
using DeliverySystem.Patterns.Strategies;

namespace DeliverySystem.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public OrderType Type { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Total { get; set; }
        public IOrderState? CurrentState { get; set; }
        public IPricingStrategy? PricingStrategy { get; set; }        

        public void CalculateTotal()
        {
            Subtotal = 0;
            foreach (var item in Items)
            {
                Subtotal += item.TotalPrice;
            }

            PricingStrategy?.CalculatePrice(this);
        }

        public void Process()
        {
            CurrentState?.Process(this);
        }

        public void NextState()
        {
            CurrentState?.Next(this);
        }

        public void PreviousState()
        {
            CurrentState?.Previous(this);
        }
        
    }
}