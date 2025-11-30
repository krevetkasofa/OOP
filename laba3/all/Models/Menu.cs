// Models/Menu.cs
using System.Collections.Generic;

namespace laba3.Models
{
    public class Menu
    {
        private readonly List<Dish> _dishes = new List<Dish>();

        public IReadOnlyList<Dish> Dishes => _dishes.AsReadOnly();

        public Menu()
        {
            _dishes.Add(new Dish(1, "Пицца 'Маргарита'", "Классическая пицца с томатным соусом и моцареллой", 450m));
            _dishes.Add(new Dish(2, "Паста Карбонара", "Спагетти с беконом, сыром и соусом из яиц", 380m));
            _dishes.Add(new Dish(3, "Цезарь с курицей", "Салат с листьями айсберг, курицей-гриль и соусом Цезарь", 320m));
        }

        // Исправляем метод - теперь он явно возвращает Dish? (nullable)
        public Dish? GetDishById(int id)
        {
            return _dishes.Find(d => d.Id == id);
        }
    }
}