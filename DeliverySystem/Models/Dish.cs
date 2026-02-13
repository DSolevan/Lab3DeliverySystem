using DeliverySystem.Models.Enums;

namespace DeliverySystem.Models
{
    public class Dish
    {

        public Dish(int id, string name, string description, decimal price, DishCategory category, int preparationTime)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            PreparationTime = preparationTime;
        }

        public Dish(Dish other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Id = other.Id;
            Name = other.Name;
            Description = other.Description;
            Price = other.Price;
            Category = other.Category;
            PreparationTime = other.PreparationTime;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DishCategory Category { get; set; }
        public int PreparationTime { get; set; } 



    }
}