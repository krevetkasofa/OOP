// Patterns/Strategy/ExpressCalculationStrategy.cs
using System.Linq;
using laba3.Models;

namespace laba3.Patterns.Strategy
{
    public class ExpressCalculationStrategy : ICalculationStrategy
    {
        private const decimal TaxRate = 0.1m;
        private const decimal ExpressDeliveryFee = 200m;
        private const decimal ExpressMultiplier = 1.1m; // Наценка за срочность

        public decimal CalculateTotal(Order order)
        {
            decimal itemsTotal = order.Items.Sum(item => item.Price);
            decimal tax = itemsTotal * TaxRate;
            decimal expressSurcharge = itemsTotal * (ExpressMultiplier - 1);
            return itemsTotal + expressSurcharge + tax + ExpressDeliveryFee;
        }
    }
}