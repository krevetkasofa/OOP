// Patterns/Strategy/PromotionalCalculationStrategy.cs
using System.Linq;
using laba3.Models;

namespace laba3.Patterns.Strategy
{
    public class PromotionalCalculationStrategy : ICalculationStrategy
    {
        private const decimal TaxRate = 0.1m;
        private const decimal DeliveryFee = 50m; // Сниженная плата за доставку по акции
        private const decimal FreeDeliveryThreshold = 1000m; // Бесплатная доставка от 1000 руб

        public decimal CalculateTotal(Order order)
        {
            decimal itemsTotal = order.Items.Sum(item => item.Price);
            decimal tax = itemsTotal * TaxRate;
            
            // Бесплатная доставка при заказе от 1000 руб
            decimal actualDeliveryFee = itemsTotal >= FreeDeliveryThreshold ? 0 : DeliveryFee;
            
            return itemsTotal + tax + actualDeliveryFee;
        }
    }
}