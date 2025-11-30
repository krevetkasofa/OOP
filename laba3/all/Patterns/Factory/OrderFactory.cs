// Patterns/Factory/OrderFactory.cs
using laba3.Models;  // Меняем Core на Models
using laba3.Patterns.Factory;

namespace laba3.Patterns.Factory
{
    public static class OrderFactory
    {
        public static Order CreateStandardOrder(string customerName, string address)
        {
            return new StandardOrder(customerName, address);
        }

        public static Order CreateExpressOrder(string customerName, string address)
        {
            return new ExpressOrder(customerName, address);
        }
    }
}