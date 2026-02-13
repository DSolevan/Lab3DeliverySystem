using DeliverySystem.Models;

namespace DeliverySystem.Patterns.States
{
    public class CompletedState : IOrderState
    {
        public void Process(Order order) { }

        public void Next(Order order) { }

        public void Previous(Order order) { }
    }
}