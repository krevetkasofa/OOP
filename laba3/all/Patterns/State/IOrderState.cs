// Patterns/State/IOrderState.cs
namespace laba3.Patterns.State
{
    public interface IOrderState
    {
        void NextStatus(Models.Order order);  // Используем полное имя
        void PreviousStatus(Models.Order order);
        string GetStatusName();
    }
}