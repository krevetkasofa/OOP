using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineLab
{   

    public enum CoinDenomination
    {
        OneRuble = 1,
        TwoRubles = 2, 
        FiveRubles = 5,
        TenRubles = 10,
        HundRubles = 100
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string name, int price, int quantity)
        {
            Id = id; Name = name; Price = price; Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Price} руб. (Осталось: {Quantity})";
        }
    }

    public class VendingMachine
    {
       
        public Dictionary<int, Product> Products { get; private set; }

        public Dictionary<CoinDenomination, int> CoinInventory { get; private set; }

        public Dictionary<CoinDenomination, int> CurrentSessionBalance { get; private set; }

        public VendingMachine()
        {
            Products = new Dictionary<int, Product>();
            CoinInventory = new Dictionary<CoinDenomination, int>();
            CurrentSessionBalance = new Dictionary<CoinDenomination, int>();

            foreach (CoinDenomination denomination in System.Enum.GetValues(typeof(CoinDenomination)))
            {
                CoinInventory.Add(denomination, 0);
                CurrentSessionBalance.Add(denomination, 0);
            }
        }

        public void AddProduct(Product product)
        {
            if (Products.ContainsKey(product.Id))
            {
                Products[product.Id].Quantity += product.Quantity;
            }
            else
            {
                Products.Add(product.Id, product);
            }
        }

        public void InsertCoin(CoinDenomination denomination)
        {
            CurrentSessionBalance[denomination] += 1;

            CoinInventory[denomination] += 1;

            Console.WriteLine($"Брошена монета: {denomination} ({(int)denomination} руб.)");
            Console.WriteLine($"Текущий баланс: {GetCurrentBalance()} руб.");
        }

        public decimal GetCurrentBalance()
        {
            decimal total = 0;
            foreach (var coin in CurrentSessionBalance)
            {
                total += (int)coin.Key * coin.Value;
            }
            return total;
        }

        public void DisplayProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("Автомат пуст! Обратитесь к администратору.");
                return;
            }

            Console.WriteLine("\n=== ДОСТУПНЫЕ ТОВАРЫ ===");
            foreach (var product in Products.Values) 
            {
                Console.WriteLine(product); 
            }
        }


        public bool TryBuyProduct(int productId)
        {
            if (!Products.ContainsKey(productId))
            {
               Console.WriteLine("Ошибка: Товара с таким ID не существует.");
               return false;
            }

            Product selectedProduct = Products[productId];

            if (selectedProduct.Quantity <= 0)
            {
               Console.WriteLine($"К сожалению, {selectedProduct.Name} закончился.");
               return false;
            }

            decimal currentBalance = GetCurrentBalance();

            if (currentBalance < selectedProduct.Price)
            {
               Console.WriteLine($"Недостаточно средств. Нужно: {selectedProduct.Price} руб., внесено: {currentBalance} руб.");
               return false;
            }

            Console.WriteLine($"Покупка {selectedProduct.Name} за {selectedProduct.Price} руб...");

            selectedProduct.Quantity -= 1;

            decimal changeAmount = currentBalance - selectedProduct.Price;
            Console.WriteLine($"Ваша сдача: {changeAmount} руб.");

            if (changeAmount > 0)
            {
               GiveChange(changeAmount);
            }
            else
            {
               Console.WriteLine("Сдача не требуется.");
            }

            ResetSessionBalance();
            Console.WriteLine("Покупка завершена! Заберите ваш товар.");
            return true;
        }
        
        private void GiveChange(decimal changeAmount)
        {

           decimal remainingChange = changeAmount;
           var changeCoins = new Dictionary<CoinDenomination, int>();
           var denominations = CoinInventory.Keys.OrderByDescending(d => (int)d);

           foreach (var denomination in denominations)
           {
            int coinValue = (int)denomination;
            if (coinValue > remainingChange || CoinInventory[denomination] == 0)
                continue; 

             int numberOfCoins = (int)(remainingChange / coinValue);
             numberOfCoins = Math.Min(numberOfCoins, CoinInventory[denomination]);

            if (numberOfCoins > 0)
            {
                changeCoins[denomination] = numberOfCoins;
                remainingChange -= numberOfCoins * coinValue;
                CoinInventory[denomination] -= numberOfCoins;

                if (remainingChange <= 0) break;
            }
           }

           if (remainingChange > 0)
           {
             Console.WriteLine("Внимание: В автомате недостаточно монет для выдачи полной сдачи!");
           }

            Console.WriteLine("Выдаваемая сдача:");
            foreach (var coin in changeCoins)
           {
             Console.WriteLine($"- Монета {(int)coin.Key} руб.: {coin.Value} шт.");
           }
        }
        private void ResetSessionBalance()
        {
          foreach (var denomination in CurrentSessionBalance.Keys.ToList())
          {
             CurrentSessionBalance[denomination] = 0;
          }
        }  

        public void ReturnMoney()
        {
          decimal returnedAmount = GetCurrentBalance();
    
          if (returnedAmount == 0)
          {
             Console.WriteLine("Нет денег для возврата.");
             return;
          }

        
        Console.WriteLine($"Возврат денег: {returnedAmount} руб.");
        Console.WriteLine("Возвращаемые монеты:");
        foreach (var coin in CurrentSessionBalance)
        {
            if (coin.Value > 0)
            {
               Console.WriteLine($"- Монета {(int)coin.Key} руб.: {coin.Value} шт.");
               CoinInventory[coin.Key] -= coin.Value;
            }
        }

        ResetSessionBalance();
    
        Console.WriteLine("Деньги успешно возвращены.");
        }
        public void AdminAddCoins(CoinDenomination denomination, int quantity)
        {
            CoinInventory[denomination] += quantity;
            Console.WriteLine($"Добавлено {quantity} монет по {(int)denomination} руб.");
        }

        public decimal AdminCollectMoney()
        {
            decimal totalCollected = 0;

            foreach (var coin in CoinInventory)
            {
                int coinValue = (int)coin.Key;
                totalCollected += coinValue * coin.Value;
            }

            foreach (var denomination in CoinInventory.Keys.ToList())
            {
                CoinInventory[denomination] = 0;
            }

            Console.WriteLine($"Собрано средств: {totalCollected} руб.");
            return totalCollected;
        }

        public void AdminDisplayStatus()
        {
            Console.WriteLine("\nСТАТУС АВТОМАТА");

            Console.WriteLine("Монеты в банке:");
            foreach (var coin in CoinInventory)
            {
                if (coin.Value > 0)
                {
                    Console.WriteLine($"- Монета {(int)coin.Key} руб.: {coin.Value} шт.");
                }
            }
            Console.WriteLine($"Общая сумма в банке: {AdminGetTotalMoney()} руб.");

            Console.WriteLine("\nТовары:");
            foreach (var product in Products.Values)
            {
                Console.WriteLine($"- {product.Name}: {product.Quantity} шт. по {product.Price} руб.");
            }
        }

        private decimal AdminGetTotalMoney()
        {
            decimal total = 0;
            foreach (var coin in CoinInventory)
            {
                total += (int)coin.Key * coin.Value;
            }
            return total;
        }
    }    
}