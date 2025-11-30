// Patterns/Factory/StandardOrder.cs
using laba3.Models;

namespace laba3.Patterns.Factory
{
    public class StandardOrder : Order
    {
        public StandardOrder(string customerName, string address) 
            : base(customerName, address)
        {
            // Устанавливаем базовую стратегию расчета
            SetCalculationStrategy(new Strategy.BaseCalculationStrategy());
        }
    }
}