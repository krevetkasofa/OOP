using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ВЕНДИНГОВЫЙ АВТОМАТ ===");
            
            // Создаем и настраиваем автомат
            VendingMachine machine = new VendingMachine();
            
            // Добавляем начальные товары
            machine.AddProduct(new Product(1, "Кола", 95, 5));
            machine.AddProduct(new Product(2, "Чипсы", 65, 3));
            machine.AddProduct(new Product(3, "Вода", 40, 10));
            machine.AddProduct(new Product(4, "Шоколадка", 80, 20));
            
            // Добавляем начальные монеты для сдачи
            machine.AdminAddCoins(CoinDenomination.TenRubles, 10);
            machine.AdminAddCoins(CoinDenomination.FiveRubles, 10);
            machine.AdminAddCoins(CoinDenomination.TwoRubles, 10);
            machine.AdminAddCoins(CoinDenomination.OneRuble, 10);

            bool isRunning = true;
            
            while (isRunning)
            {
                Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1 - Посмотреть товары");
                Console.WriteLine("2 - Внести монеты");
                Console.WriteLine("3 - Купить товар");
                Console.WriteLine("4 - Вернуть деньги");
                Console.WriteLine("5 - Админ-панель");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1": // Посмотреть товары
                        machine.DisplayProducts();
                        break;
                        
                    case "2": // Внести монеты
                        Console.WriteLine("\nДоступные номиналы:");
                        Console.WriteLine("1 - 1 рубль");
                        Console.WriteLine("2 - 2 рубля");
                        Console.WriteLine("5 - 5 рублей");
                        Console.WriteLine("10 - 10 рублей");
                        Console.WriteLine("100 - 100 рублей");
                        Console.Write("Выберите номинал: ");
                        
                        if (int.TryParse(Console.ReadLine(), out int coinValue))
                        {
                            CoinDenomination denomination = (CoinDenomination)coinValue;
                            machine.InsertCoin(denomination);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод!");
                        }
                        break;
                        
                    case "3": // Купить товар
                        machine.DisplayProducts();
                        Console.Write("Введите ID товара: ");
                        
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            machine.TryBuyProduct(productId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ID");
                        }
                        break;
                        
                    case "4": // Вернуть деньги
                        machine.ReturnMoney();
                        break;
                        
                    case "5": // Админ-панель
                        Console.WriteLine("\n=== АДМИН-ПАНЕЛЬ ===");
                        Console.WriteLine("1 - Посмотреть статус");
                        Console.WriteLine("2 - Пополнить монеты");
                        Console.WriteLine("3 - Собрать деньги");
                        Console.Write("Выберите действие: ");
                        
                        string adminChoice = Console.ReadLine();
                        switch (adminChoice)
                        {
                            case "1":
                                machine.AdminDisplayStatus();
                                break;
                            case "2":
                                Console.WriteLine("Введите номинал (1,2,5,10,100): ");
                                if (int.TryParse(Console.ReadLine(), out int adminCoinValue))
                                {
                                    Console.WriteLine("Введите количество: ");
                                    if (int.TryParse(Console.ReadLine(), out int quantity))
                                    {
                                        machine.AdminAddCoins((CoinDenomination)adminCoinValue, quantity);
                                    }
                                }
                                break;
                            case "3":
                                machine.AdminCollectMoney();
                                break;
                            default:
                                Console.WriteLine("Неверный выбор");
                                break;
                        }
                        break;
                        
                    case "0": // Выход
                        isRunning = false;
                        Console.WriteLine("До свидания!");
                        break;
                        
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
    }
}