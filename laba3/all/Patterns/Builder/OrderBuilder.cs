// Patterns/Builder/OrderBuilder.cs
using System;
using System.Collections.Generic;
using laba3.Models;
using laba3.Patterns.Factory;
using laba3.Patterns.Strategy;

namespace laba3.Patterns.Builder
{
    public class OrderBuilder
    {
        private string? _customerName;  // Добавляем ? для nullable
        private string? _address;       // Добавляем ? для nullable
        private readonly List<Dish> _items = new List<Dish>();
        private OrderType _orderType = OrderType.Standard;
        private ICalculationStrategy? _calculationStrategy;  // Добавляем ? для nullable

        public OrderBuilder SetCustomer(string customerName)
        {
            _customerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
            return this;
        }

        public OrderBuilder SetAddress(string address)
        {
            _address = address ?? throw new ArgumentNullException(nameof(address));
            return this;
        }

        public OrderBuilder AddItem(Dish dish)
        {
            _items.Add(dish ?? throw new ArgumentNullException(nameof(dish)));
            return this;
        }

        public OrderBuilder AddItems(IEnumerable<Dish> dishes)
        {
            foreach (var dish in dishes)
            {
                AddItem(dish);
            }
            return this;
        }

        public OrderBuilder SetOrderType(OrderType orderType)
        {
            _orderType = orderType;
            return this;
        }

        public OrderBuilder SetCalculationStrategy(ICalculationStrategy strategy)
        {
            _calculationStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            return this;
        }

        public Order Build()
        {
            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException("Customer name is required");
            if (string.IsNullOrWhiteSpace(_address))
                throw new InvalidOperationException("Address is required");
            if (_items.Count == 0)
                throw new InvalidOperationException("At least one item is required");

            Order order = _orderType switch
            {
                OrderType.Standard => OrderFactory.CreateStandardOrder(_customerName, _address),
                OrderType.Express => OrderFactory.CreateExpressOrder(_customerName, _address),
                _ => throw new InvalidOperationException("Unknown order type")
            };

            foreach (var item in _items)
            {
                order.Items.Add(item);
            }

            if (_calculationStrategy != null)
            {
                order.SetCalculationStrategy(_calculationStrategy);
            }

            return order;
        }
    }

    public enum OrderType
    {
        Standard,
        Express
    }
}