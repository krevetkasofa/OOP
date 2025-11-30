// Models/Order.cs
using System.Collections.Generic;
using laba3.Patterns.State;
using laba3.Patterns.Strategy;  // ДОБАВИТЬ ЭТУ СТРОЧКУ
using laba3.Patterns.Observer;

namespace laba3.Models
{
    public abstract class Order : IOrderObservable
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<Dish> Items { get; set; } = new List<Dish>();
        
        private IOrderState _state;
        private ICalculationStrategy _calculationStrategy;
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        protected Order(string customerName, string address)
        {
            CustomerName = customerName;
            Address = address;
            _state = new Patterns.State.PreparingState();
            _calculationStrategy = new Patterns.Strategy.BaseCalculationStrategy(); // ИСПРАВИТЬ ЭТУ СТРОКУ
        }

        // остальной код без изменений...
        public decimal CalculateTotal()
        {
            return _calculationStrategy.CalculateTotal(this);
        }

        public void NextStatus()
        {
            string oldStatus = GetCurrentStatus();
            _state.NextStatus(this);
            string newStatus = GetCurrentStatus();
            
            if (oldStatus != newStatus)
            {
                NotifyObservers(oldStatus, newStatus);
            }
        }

        public void PreviousStatus()
        {
            string oldStatus = GetCurrentStatus();
            _state.PreviousStatus(this);
            string newStatus = GetCurrentStatus();
            
            if (oldStatus != newStatus)
            {
                NotifyObservers(oldStatus, newStatus);
            }
        }

        public string GetCurrentStatus() => _state.GetStatusName();
        
        public void SetState(IOrderState state)
        {
            _state = state;
        }

        public void SetCalculationStrategy(ICalculationStrategy strategy)
        {
            _calculationStrategy = strategy;
        }

        public void AddObserver(IOrderObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string oldStatus, string newStatus)
        {
            foreach (var observer in _observers)
            {
                observer.Update(this, oldStatus, newStatus);
            }
        }
    }
}