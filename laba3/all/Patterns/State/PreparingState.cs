// Patterns/State/PreparingState.cs
using laba3.Models;  // Добавляем using

namespace laba3.Patterns.State
{
    public class PreparingState : IOrderState
    {
        public void NextStatus(Order order)
        {
            // Из "Подготовка" можно перейти только в "Доставка"
            order.SetState(new DeliveringState());
        }

        public void PreviousStatus(Order order)
        {
            // Из "Подготовка" нельзя перейти назад - это начальное состояние
            throw new InvalidOperationException("Заказ уже находится в начальном статусе подготовки");
        }

        public string GetStatusName()
        {
            return "Preparing";
        }
    }
}