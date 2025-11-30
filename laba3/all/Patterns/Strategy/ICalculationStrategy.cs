// Patterns/Strategy/ICalculationStrategy.cs
using laba3.Models;

namespace laba3.Patterns.Strategy
{
    public interface ICalculationStrategy
    {
        decimal CalculateTotal(Order order);
    }
}