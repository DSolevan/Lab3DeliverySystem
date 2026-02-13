using DeliverySystem.Models;
using DeliverySystem.Models.Enums;

namespace DeliverySystem.Patterns.Services
{
    public class MenuService
    {
        private List<Dish> _dishes;

        public MenuService()
        {
            _dishes = new List<Dish>();
        }

        public List<Dish> GetMenu()
        {
            return new List<Dish>(_dishes);
        }

        public Dish GetDishById(int id)
        {
            var dish = _dishes.Find(d => d.Id == id);
            if (dish == null)
                throw new InvalidOperationException($"Блюдо с ID {id} не найдено");

            return dish;
        }

        public void AddDish(Dish dish)
        {
            _dishes.Add(dish);
        }
    }
}
