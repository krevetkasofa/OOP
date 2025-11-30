// Patterns/Observer/NotificationObserver.cs
using System;
using laba3.Models;

namespace laba3.Patterns.Observer
{
    public class NotificationObserver : IOrderObserver
    {
        public void Update(Order order, string oldStatus, string newStatus)
        {
            // В реальной системе здесь была бы отправка email/SMS/push-уведомления
            Console.WriteLine($"[NOTIFICATION] Dear {order.CustomerName}, your order status is now: {newStatus}");
            
            if (newStatus == "Delivering")
            {
                Console.WriteLine($"[NOTIFICATION] Your order is on the way to {order.Address}");
            }
            else if (newStatus == "Completed")
            {
                Console.WriteLine($"[NOTIFICATION] Thank you for your order! We hope you enjoy your meal!");
            }
        }
    }
}