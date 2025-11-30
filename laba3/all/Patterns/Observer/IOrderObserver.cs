// Patterns/Observer/IOrderObserver.cs
using laba3.Models;

namespace laba3.Patterns.Observer
{
    public interface IOrderObserver
    {
        void Update(Order order, string oldStatus, string newStatus);
    }
}