using DeliverySystem.Models;

namespace DeliverySystem.Patterns.States
{
    public class PreparingState : IOrderState
    {
        public void Process(Order order) { }

        public void Next(Order order)
        {
            order.CurrentState = new DeliveringState();
        }

        public void Previous(Order order) { }
    }
}
