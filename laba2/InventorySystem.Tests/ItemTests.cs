using Xunit;

namespace InventorySystem.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Weapon_Create_ShouldHaveCorrectProperties()
        {
            // Arrange & Act
            var weapon = new Weapon("w1", "Sword", "Sharp sword", 5, 15);

            // Assert
            Assert.Equal("w1", weapon.Id);
            Assert.Equal("Sword", weapon.Name);
            Assert.Equal(ItemType.Weapon, weapon.Type);
            Assert.Equal(15, weapon.Damage);
            Assert.Equal(1, weapon.Level);
            Assert.False(weapon.IsEquipped);
        }

        [Fact]
        public void Weapon_Upgrade_ShouldIncreaseLevelAndDamage()
        {
            // Arrange
            var weapon = new Weapon("w1", "Sword", "Sharp sword", 5, 15);
            var initialDamage = weapon.Damage;

            // Act
            weapon.Upgrade();

            // Assert
            Assert.Equal(2, weapon.Level);
            Assert.True(weapon.Damage > initialDamage);
        }

        [Fact]
        public void Armor_Equip_ShouldChangeState()
        {
            // Arrange
            var armor = new Armor("a1", "Helmet", "Iron helmet", 3, 5);

            // Act
            armor.Equip();

            // Assert
            Assert.True(armor.IsEquipped);
        }

        [Fact]
        public void Potion_Use_ShouldWork()
        {
            // Arrange
            var potion = new Potion("p1", "Health Potion", "Heals wounds", 1, 50);

            // Act & Assert
            // Проверяем, что метод не выбрасывает исключений
            var exception = Record.Exception(() => potion.Use());
            Assert.Null(exception);
        }
    }
}