// Patterns/Strategy/BaseCalculationStrategy.cs
using System.Linq;
using laba3.Models;

namespace laba3.Patterns.Strategy
{
    public class BaseCalculationStrategy : ICalculationStrategy
    {
        private const decimal TaxRate = 0.1m; // 10% налог
        private const decimal DeliveryFee = 100m;

        public decimal CalculateTotal(Order order)
        {
            decimal itemsTotal = order.Items.Sum(item => item.Price);
            decimal tax = itemsTotal * TaxRate;
            return itemsTotal + tax + DeliveryFee;
        }
    }
}