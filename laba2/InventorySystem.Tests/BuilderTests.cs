using Xunit;

namespace InventorySystem.Tests
{
    public class BuilderTests
    {
        [Fact]
        public void WeaponBuilder_ShouldBuildWeaponWithCorrectProperties()
        {
            // Arrange
            var builder = new WeaponBuilder("w1");

            // Act - вызываем методы по отдельности
            builder.SetName("Dragon Slayer");
            builder.SetDescription("Legendary sword");
            builder.SetWeight(8);
            builder.SetDamage(35); // Этот метод работает с конкретным WeaponBuilder
            
            var weapon = builder.Build();

            // Assert
            Assert.Equal("Dragon Slayer", weapon.Name);
            Assert.Equal("Legendary sword", weapon.Description);
            Assert.Equal(8, weapon.Weight);
            Assert.Equal(35, weapon.Damage);
        }

        [Fact]
        public void ArmorBuilder_ShouldBuildArmorWithCorrectProperties()
        {
            // Arrange
            var builder = new ArmorBuilder("a1");

            // Act - вызываем методы по отдельности
            builder.SetName("Dragon Scale Armor");
            builder.SetDescription("Armor made from dragon scales");
            builder.SetWeight(15);
            builder.SetDefense(25); // Этот метод работает с конкретным ArmorBuilder
            
            var armor = builder.Build();

            // Assert
            Assert.Equal("Dragon Scale Armor", armor.Name);
            Assert.Equal("Armor made from dragon scales", armor.Description);
            Assert.Equal(15, armor.Weight);
            Assert.Equal(25, armor.Defense);
        }
    }
}