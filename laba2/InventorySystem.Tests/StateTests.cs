using Xunit;

namespace InventorySystem.Tests
{
    public class StateTests
    {
        [Fact]
        public void EquippedState_HandleEquip_ShouldReturnAlreadyEquippedMessage()
        {
            // Arrange
            var state = new EquippedState();
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);
            weapon.Equip();

            // Act
            using var consoleOutput = new ConsoleOutput();
            state.HandleEquip(weapon);

            // Assert
            Assert.Contains("already equipped", consoleOutput.GetOutput());
        }

        [Fact]
        public void UnequippedState_HandleEquip_ShouldEquipItem()
        {
            // Arrange
            var state = new UnequippedState();
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);

            // Act
            using var consoleOutput = new ConsoleOutput();
            state.HandleEquip(weapon);

            // Assert
            Assert.True(weapon.IsEquipped);
            Assert.Contains("has been equipped", consoleOutput.GetOutput());
        }

        [Fact]
        public void UsedState_HandleUse_ShouldReturnAlreadyUsedMessage()
        {
            // Arrange
            var state = new UsedState();
            var potion = new Potion("p1", "Potion", "Test", 1, 50);

            // Act
            using var consoleOutput = new ConsoleOutput();
            state.HandleUse(potion);

            // Assert
            Assert.Contains("already been used", consoleOutput.GetOutput());
        }

        [Fact]
        public void Inventory_UseItem_ShouldChangeStateForPotion()
        {
            // Arrange
            var inventory = new Inventory(50);
            var potion = new Potion("p1", "Health Potion", "Heals", 1, 50);
            inventory.AddItem(potion);

            // Act
            using var consoleOutput = new ConsoleOutput();
            inventory.UseItem("p1");

            // Assert
            // Проверяем что зелье было удалено после использования
            Assert.DoesNotContain(potion, inventory.Items);
        }

        [Fact]
        public void Inventory_EquipItem_ShouldChangeStateToEquipped()
        {
            // Arrange
            var inventory = new Inventory(50);
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);
            inventory.AddItem(weapon);

            // Act
            inventory.EquipItem("w1");

            // Assert
            Assert.True(weapon.IsEquipped);
        }
    }

    // Вспомогательный класс для перехвата вывода консоли
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}