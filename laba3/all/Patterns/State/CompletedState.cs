// Patterns/State/CompletedState.cs
using laba3.Models;  // Добавляем using

namespace laba3.Patterns.State
{
    public class CompletedState : IOrderState
    {
        public void NextStatus(Order order)
        {
            // Из "Выполнен" нельзя перейти дальше
            throw new InvalidOperationException("Заказ уже завершен");
        }

        public void PreviousStatus(Order order)
        {
            // Из "Выполнен" можно вернуться в "Доставка"
            order.SetState(new DeliveringState());
        }

        public string GetStatusName()
        {
            return "Completed";
        }
    }
}