public class EpicItemFactory : IItemFactory
{
    public Weapon CreateWeapon(string name, int baseDamage)
    {
        var epicDamage = (int)(baseDamage * 2.0);
        var builder = new WeaponBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[EPIC] {name}");
        builder.SetDescription($"An epic {name} with massive damage");
        builder.SetWeight(1);
        builder.SetDamage(epicDamage);
        return builder.Build();
    }

    public Armor CreateArmor(string name, int baseDefense)
    {
        var epicDefense = (int)(baseDefense * 1.8);
        var builder = new ArmorBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[EPIC] {name}");
        builder.SetDescription($"An epic {name} with massive defense");
        builder.SetWeight(4);
        builder.SetDefense(epicDefense);
        return builder.Build();
    }

    public Potion CreatePotion(string name, int healingPower)
    {
        var epicHealing = (int)(healingPower * 2.5);
        var builder = new PotionBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[EPIC] {name}");
        builder.SetDescription($"An epic {name} with massive healing");
        builder.SetWeight(1);
        builder.SetHealingPower(epicHealing);
        return builder.Build();
    }

    public QuestItem CreateQuestItem(string name, string description)
    {
        return new QuestItemBuilder(Guid.NewGuid().ToString())
            .SetName($"[EPIC] {name}")
            .SetDescription(description)
            .SetWeight(1)
            .Build();
    }
}