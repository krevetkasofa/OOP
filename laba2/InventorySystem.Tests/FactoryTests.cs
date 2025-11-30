using Xunit;

namespace InventorySystem.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void CommonItemFactory_ShouldCreateCommonItems()
        {
            // Arrange
            var factory = new CommonItemFactory();

            // Act
            var weapon = factory.CreateWeapon("Sword", 15);
            var armor = factory.CreateArmor("Helmet", 10);

            // Assert
            Assert.NotNull(weapon);
            Assert.NotNull(armor);
            Assert.IsType<Weapon>(weapon);
            Assert.IsType<Armor>(armor);
            Assert.DoesNotContain("[Rare]", weapon.Name);
            Assert.DoesNotContain("[EPIC]", armor.Name);
        }

        [Fact]
        public void RareItemFactory_ShouldCreateEnhancedItems()
        {
            // Arrange
            var factory = new RareItemFactory();

            // Act
            var weapon = factory.CreateWeapon("Sword", 15);
            var armor = factory.CreateArmor("Helmet", 10);

            // Assert
            Assert.Contains("[Rare]", weapon.Name);
            Assert.Contains("[Rare]", armor.Name);
            Assert.True(weapon.Damage > 15); // Улучшенный урон
            Assert.True(armor.Defense > 10); // Улучшенная защита
        }

        [Fact]
        public void EpicItemFactory_ShouldCreateEpicItems()
        {
            // Arrange
            var factory = new EpicItemFactory();

            // Act
            var weapon = factory.CreateWeapon("Sword", 15);
            var potion = factory.CreatePotion("Health Potion", 50);

            // Assert
            Assert.Contains("[EPIC]", weapon.Name);
            Assert.Contains("[EPIC]", potion.Name);
            Assert.True(weapon.Damage >= 30); // Сильно улучшенный урон (15 * 2.0)
            Assert.True(potion.HealingPower >= 125); // Сильно улучшенное лечение (50 * 2.5)
        }

        [Fact]
        public void DifferentFactories_ShouldCreateDifferentItems()
        {
            // Arrange
            var commonFactory = new CommonItemFactory();
            var rareFactory = new RareItemFactory();

            // Act
            var commonWeapon = commonFactory.CreateWeapon("Sword", 20);
            var rareWeapon = rareFactory.CreateWeapon("Sword", 20);

            // Assert
            Assert.NotEqual(commonWeapon.Damage, rareWeapon.Damage);
            Assert.NotEqual(commonWeapon.Name, rareWeapon.Name);
            Assert.True(rareWeapon.Damage > commonWeapon.Damage);
        }
    }
}