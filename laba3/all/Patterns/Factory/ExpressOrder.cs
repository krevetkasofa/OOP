// Patterns/Factory/ExpressOrder.cs
using laba3.Models;
using laba3.Patterns.Strategy;

namespace laba3.Patterns.Factory
{
    public class ExpressOrder : Order
    {
        public ExpressOrder(string customerName, string address) 
            : base(customerName, address)
        {
            // Для экспресс-заказов используем специальную стратегию
            SetCalculationStrategy(new ExpressCalculationStrategy());
        }
    }
}