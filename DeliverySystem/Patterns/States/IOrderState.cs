using DeliverySystem.Models;

namespace DeliverySystem.Patterns.States
{
   
    public interface IOrderState
    {
        void Process(Order order);

        void Next(Order order);

        void Previous(Order order);

    }
}
