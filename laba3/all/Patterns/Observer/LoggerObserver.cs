// Patterns/Observer/LoggerObserver.cs
using System;
using laba3.Models;

namespace laba3.Patterns.Observer
{
    public class LoggerObserver : IOrderObserver
    {
        public void Update(Order order, string oldStatus, string newStatus)
        {
            Console.WriteLine($"[LOG] Order #{order.Id} status changed: {oldStatus} -> {newStatus}");
            Console.WriteLine($"[LOG] Customer: {order.CustomerName}, Total: {order.CalculateTotal():C}");
        }
    }
}