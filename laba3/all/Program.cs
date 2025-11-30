using laba3.Models;
using laba3.Patterns.Factory;
using laba3.Patterns.Builder;
using laba3.Patterns.Strategy;
using laba3.Patterns.Observer;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ ЗАКАЗАМИ ДОСТАВКИ ===\n");
            
            var menu = new Menu();
            var director = new OrderDirector(menu);

            // Демонстрация паттерна Фабричный Метод
            Console.WriteLine("1. ПАТТЕРН ФАБРИЧНЫЙ МЕТОД");
            Console.WriteLine("==========================");
            var standardOrder = OrderFactory.CreateStandardOrder("Иван Иванов", "ул. Ленина, 123");
            var expressOrder = OrderFactory.CreateExpressOrder("Петр Петров", "ул. Центральная, 45");
            
            Console.WriteLine($"Стандартный заказ: {standardOrder.GetType().Name}");
            Console.WriteLine($"Экспресс заказ: {expressOrder.GetType().Name}\n");

            // Демонстрация паттерна Строитель
            Console.WriteLine("2. ПАТТЕРН СТРОИТЕЛЬ");
            Console.WriteLine("====================");
            var customOrder = new OrderBuilder()
                .SetCustomer("Анна Сидорова")
                .SetAddress("пр. Победы, 67")
                .AddItem(menu.GetDishById(1)!)
                .AddItem(menu.GetDishById(3)!)
                .SetOrderType(OrderType.Standard)
                .Build();
            
            Console.WriteLine($"Заказ через Builder: {customOrder.CustomerName}");
            Console.WriteLine($"Адрес: {customOrder.Address}");
            Console.WriteLine($"Количество блюд: {customOrder.Items.Count}\n");

            // Демонстрация паттерна Стратегия
            Console.WriteLine("3. ПАТТЕРН СТРАТЕГИЯ");
            Console.WriteLine("====================");
            
            var pizza = menu.GetDishById(1)!;
            var pasta = menu.GetDishById(2)!;
            
            var calculationOrder = OrderFactory.CreateStandardOrder("Тест Стратегии", "ул. Тестовая, 1");
            calculationOrder.Items.Add(pizza);
            calculationOrder.Items.Add(pasta);
            
            Console.WriteLine("Базовый расчет:");
            decimal baseTotal = calculationOrder.CalculateTotal();
            Console.WriteLine($"Сумма: {baseTotal:C}");
            
            Console.WriteLine("Расчет со скидкой постоянного клиента:");
            calculationOrder.SetCalculationStrategy(new LoyaltyCalculationStrategy());
            decimal loyaltyTotal = calculationOrder.CalculateTotal();
            Console.WriteLine($"Сумма: {loyaltyTotal:C}");
            Console.WriteLine($"Экономия: {baseTotal - loyaltyTotal:C}\n");

            // Демонстрация паттернов Состояние и Наблюдатель
            Console.WriteLine("4. ПАТТЕРНЫ СОСТОЯНИЕ И НАБЛЮДАТЕЛЬ");
            Console.WriteLine("===================================");
            
            var observedOrder = director.BuildQuickLunchOrder("Наблюдаемый Клиент", "ул. Наблюдаемая, 99");
            
            // Подписываем наблюдателей
            observedOrder.AddObserver(new LoggerObserver());
            observedOrder.AddObserver(new NotificationObserver());
            observedOrder.AddObserver(new KitchenObserver());
            
            Console.WriteLine($"Начальный статус: {observedOrder.GetCurrentStatus()}");
            
            // Меняем статусы - наблюдатели получат уведомления
            observedOrder.NextStatus();
            Console.WriteLine($"Текущий статус: {observedOrder.GetCurrentStatus()}");
            
            observedOrder.NextStatus();
            Console.WriteLine($"Финальный статус: {observedOrder.GetCurrentStatus()}\n");

            // Демонстрация готовых сценариев через Director
            Console.WriteLine("5. ГОТОВЫЕ СЦЕНАРИИ ЧЕРЕЗ DIRECTOR");
            Console.WriteLine("==================================");
            
            var familyOrder = director.BuildFamilyDinnerOrder("Семья Сидоровых", "ул. Семейная, 12");
            var businessOrder = director.BuildExpressBusinessLunch("Бизнес-Клиент", "б-р Деловой, 34");
            
            Console.WriteLine($"Семейный ужин: {familyOrder.Items.Count} блюд, сумма: {familyOrder.CalculateTotal():C}");
            Console.WriteLine($"Бизнес-ланч: {businessOrder.Items.Count} блюд, сумма: {businessOrder.CalculateTotal():C}");

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА ===");
        }
    }
}