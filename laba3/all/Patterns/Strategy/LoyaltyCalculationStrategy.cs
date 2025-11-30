// Patterns/Strategy/LoyaltyCalculationStrategy.cs
using System.Linq;
using laba3.Models;

namespace laba3.Patterns.Strategy
{
    public class LoyaltyCalculationStrategy : ICalculationStrategy
    {
        private const decimal TaxRate = 0.1m;
        private const decimal DeliveryFee = 100m;
        private const decimal LoyaltyDiscount = 0.15m; // 15% скидка для постоянных клиентов

        public decimal CalculateTotal(Order order)
        {
            decimal itemsTotal = order.Items.Sum(item => item.Price);
            decimal tax = itemsTotal * TaxRate;
            decimal discount = itemsTotal * LoyaltyDiscount;
            return (itemsTotal - discount) + tax + DeliveryFee;
        }
    }
}