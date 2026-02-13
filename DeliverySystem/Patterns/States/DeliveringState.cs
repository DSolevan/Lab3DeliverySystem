using DeliverySystem.Models;

namespace DeliverySystem.Patterns.States
{
    public class DeliveringState : IOrderState
    {
        public void Process(Order order) { }

        public void Next(Order order)
        {
            order.CurrentState = new CompletedState();
        }

        public void Previous(Order order)
        {
            order.CurrentState = new PreparingState();
        }

    }
}