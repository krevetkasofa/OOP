// Patterns/State/DeliveringState.cs
using laba3.Models;  // Добавляем using

namespace laba3.Patterns.State
{
    public class DeliveringState : IOrderState
    {
        public void NextStatus(Order order)
        {
            // Из "Доставка" переходим в "Выполнен"
            order.SetState(new CompletedState());
        }

        public void PreviousStatus(Order order)
        {
            // Из "Доставка" можно вернуться в "Подготовка"
            order.SetState(new PreparingState());
        }

        public string GetStatusName()
        {
            return "Delivering";
        }
    }
}