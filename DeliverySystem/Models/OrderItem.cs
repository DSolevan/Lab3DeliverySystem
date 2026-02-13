namespace DeliverySystem.Models
{
    public class OrderItem
    {

        public OrderItem(Dish dish, int quantity = 1)
        {
            Dish = dish;
            Quantity = quantity;
        }


        public Dish Dish { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => Dish.Price * Quantity;

    }
}