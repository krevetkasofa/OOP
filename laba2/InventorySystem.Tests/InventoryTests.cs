using Xunit;

namespace InventorySystem.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void AddItem_ShouldAddItemToInventory()
        {
            // Arrange
            var inventory = new Inventory(50);
            var weapon = new Weapon("w1", "Sword", "Test sword", 5, 10);

            // Act
            var result = inventory.AddItem(weapon);

            // Assert
            Assert.True(result);
            Assert.Contains(weapon, inventory.Items);
        }

        [Fact]
        public void AddItem_WhenOverweight_ShouldReturnFalse()
        {
            // Arrange
            var inventory = new Inventory(5);
            var heavyWeapon = new Weapon("w1", "Heavy Sword", "Very heavy", 10, 15);

            // Act
            var result = inventory.AddItem(heavyWeapon);

            // Assert
            Assert.False(result);
            Assert.DoesNotContain(heavyWeapon, inventory.Items);
        }

        [Fact]
        public void RemoveItem_ShouldRemoveItemFromInventory()
        {
            // Arrange
            var inventory = new Inventory(50);
            var weapon = new Weapon("w1", "Sword", "Test sword", 5, 10);
            inventory.AddItem(weapon);

            // Act
            var result = inventory.RemoveItem("w1");

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(weapon, inventory.Items);
        }

        [Fact]
        public void SetSortStrategy_ShouldChangeSorting()
        {
            // Arrange
            var inventory = new Inventory(50);
            var sword = new Weapon("w1", "Sword", "Test sword", 5, 10);
            var axe = new Weapon("w2", "Axe", "Test axe", 8, 15);
            inventory.AddItem(axe);
            inventory.AddItem(sword);

            // Act
            inventory.SetSortStrategy(new NameSortStrategy());
            var sortedItems = inventory.Items.ToList();

            // Assert
            Assert.Equal("Axe", sortedItems[0].Name);
            Assert.Equal("Sword", sortedItems[1].Name);
        }

        [Fact]
        public void EquipmentManager_EquipItem_ShouldEquipWeapon()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            var weapon = new Weapon("w1", "Sword", "Test sword", 5, 10);

            // Act
            var result = equipmentManager.EquipItem(weapon);

            // Assert
            Assert.True(result);
            Assert.True(weapon.IsEquipped);
        }

        [Fact]
        public void EquipmentManager_GetTotalDamage_ShouldReturnCorrectValue()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            var weapon1 = new Weapon("w1", "Sword", "Test sword", 5, 10);
            var weapon2 = new Weapon("w2", "Axe", "Test axe", 8, 15);
            
            // Act
            equipmentManager.EquipItem(weapon1);
            equipmentManager.EquipItem(weapon2); // Заменит первый weapon
            var totalDamage = equipmentManager.GetTotalDamage();

            // Assert
            Assert.Equal(15, totalDamage); // Только последний экипированный weapon
        }
    }
}