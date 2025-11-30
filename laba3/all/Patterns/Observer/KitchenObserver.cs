// Patterns/Observer/KitchenObserver.cs
using System;
using laba3.Models;

namespace laba3.Patterns.Observer
{
    public class KitchenObserver : IOrderObserver
    {
        public void Update(Order order, string oldStatus, string newStatus)
        {
            if (newStatus == "Preparing" && oldStatus != "Preparing")
            {
                Console.WriteLine($"[KITCHEN] New order #{order.Id} received! Items: {order.Items.Count}");
                foreach (var item in order.Items)
                {
                    Console.WriteLine($"[KITCHEN] - {item.Name}");
                }
            }
        }
    }
}
