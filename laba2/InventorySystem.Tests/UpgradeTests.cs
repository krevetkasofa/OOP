using Xunit;

namespace InventorySystem.Tests
{
    public class UpgradeTests
    {
        [Fact]
        public void WeaponUpgradeService_CanUpgrade_ShouldReturnTrueForUpgradableWeapon()
        {
            // Arrange
            var service = new WeaponUpgradeService();
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);

            // Act
            var canUpgrade = service.CanUpgrade(weapon);

            // Assert
            Assert.True(canUpgrade);
        }

        [Fact]
        public void UpgradeManager_UpgradeItem_ShouldUpgradeWeapon()
        {
            // Arrange
            var manager = new UpgradeManager();
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);
            var initialLevel = weapon.Level;

            // Act
            var upgradedWeapon = manager.UpgradeItem(weapon);

            // Assert
            Assert.Equal(initialLevel + 1, ((Weapon)upgradedWeapon).Level); // Приводим тип
        }

        [Fact]
        public void PotionCombineService_CanCombine_ShouldReturnTrueForTwoPotions()
        {
            // Arrange
            var service = new PotionCombineService();
            var potion1 = new Potion("p1", "Potion", "Test", 1, 20);
            var potion2 = new Potion("p2", "Potion", "Test", 1, 30);

            // Act
            var canCombine = service.CanCombine(potion1, potion2);

            // Assert
            Assert.True(canCombine);
        }

        [Fact]
        public void UpgradeManager_CombineItems_ShouldCombinePotions()
        {
            // Arrange
            var manager = new UpgradeManager();
            var potion1 = new Potion("p1", "Health Potion", "Test", 1, 20);
            var potion2 = new Potion("p2", "Health Potion", "Test", 1, 30);

            // Act
            var combinedPotion = manager.CombineItems(potion1, potion2);

            // Assert
            Assert.NotNull(combinedPotion);
            Assert.IsType<Potion>(combinedPotion);
            Assert.Equal(50, ((Potion)combinedPotion).HealingPower); // 20 + 30
        }

        [Fact]
        public void UpgradeManager_GetUpgradeCost_ShouldReturnCorrectCost()
        {
            // Arrange
            var manager = new UpgradeManager();
            var weapon = new Weapon("w1", "Sword", "Test", 5, 10);

            // Act
            var cost = manager.GetUpgradeCost(weapon);

            // Assert
            Assert.True(cost > 0);
        }
    }
}