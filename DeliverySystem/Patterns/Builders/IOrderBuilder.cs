using DeliverySystem.Models;
using DeliverySystem.Models.Enums;

namespace DeliverySystem.Patterns.Builders
{

    public interface IOrderBuilder
    {
        void SetCustomerInfo(string name, string address);

        void AddItem(Dish dish, int quantity = 1);

        void SetOrderType(OrderType type);

        Order Build();
    }
}
