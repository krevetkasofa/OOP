// Patterns/Builder/OrderDirector.cs
using System;
using laba3.Models;
using laba3.Patterns.Strategy;

namespace laba3.Patterns.Builder
{
    public class OrderDirector
    {
        private readonly Menu _menu;

        public OrderDirector(Menu menu)
        {
            _menu = menu ?? throw new ArgumentNullException(nameof(menu));
        }

        public Order BuildQuickLunchOrder(string customerName, string address)
        {
            var pizza = _menu.GetDishById(1) ?? throw new InvalidOperationException("Pizza not found");
            var salad = _menu.GetDishById(3) ?? throw new InvalidOperationException("Salad not found");
            
            return new OrderBuilder()
                .SetCustomer(customerName)
                .SetAddress(address)
                .AddItem(pizza)
                .AddItem(salad)
                .SetOrderType(OrderType.Standard)
                .Build();
        }

        public Order BuildFamilyDinnerOrder(string customerName, string address)
        {
            var pizza1 = _menu.GetDishById(1) ?? throw new InvalidOperationException("Pizza not found");
            var pizza2 = _menu.GetDishById(1) ?? throw new InvalidOperationException("Pizza not found");
            var pasta = _menu.GetDishById(2) ?? throw new InvalidOperationException("Pasta not found");
            var salad = _menu.GetDishById(3) ?? throw new InvalidOperationException("Salad not found");
            
            var order = new OrderBuilder()
                .SetCustomer(customerName)
                .SetAddress(address)
                .AddItem(pizza1)
                .AddItem(pizza2)
                .AddItem(pasta)
                .AddItem(salad)
                .SetOrderType(OrderType.Standard)
                .SetCalculationStrategy(new LoyaltyCalculationStrategy())
                .Build();

            return order;
        }

        public Order BuildExpressBusinessLunch(string customerName, string address)
        {
            var pasta = _menu.GetDishById(2) ?? throw new InvalidOperationException("Pasta not found");
            var salad = _menu.GetDishById(3) ?? throw new InvalidOperationException("Salad not found");
            
            return new OrderBuilder()
                .SetCustomer(customerName)
                .SetAddress(address)
                .AddItem(pasta)
                .AddItem(salad)
                .SetOrderType(OrderType.Express)
                .Build();
        }
    }
}