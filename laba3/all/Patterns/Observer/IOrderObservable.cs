// Patterns/Observer/IOrderObservable.cs
namespace laba3.Patterns.Observer
{
    public interface IOrderObservable
    {
        void AddObserver(IOrderObserver observer);
        void RemoveObserver(IOrderObserver observer);
        void NotifyObservers(string oldStatus, string newStatus);
    }
}