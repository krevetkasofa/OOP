public class RareItemFactory : IItemFactory
{
    public Weapon CreateWeapon(string name, int baseDamage)
    {
        var rareDamage = (int)(baseDamage * 1.5);
        var builder = new WeaponBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[Rare] {name}");
        builder.SetDescription($"A rare {name} with enhanced damage");
        builder.SetWeight(2);
        builder.SetDamage(rareDamage);
        return builder.Build();
    }

    public Armor CreateArmor(string name, int baseDefense)
    {
        var rareDefense = (int)(baseDefense * 1.4);
        var builder = new ArmorBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[Rare] {name}");
        builder.SetDescription($"A rare {name} with enhanced defense");
        builder.SetWeight(6);
        builder.SetDefense(rareDefense);
        return builder.Build();
    }

    public Potion CreatePotion(string name, int healingPower)
    {
        var rareHealing = (int)(healingPower * 1.8);
        var builder = new PotionBuilder(Guid.NewGuid().ToString());
        builder.SetName($"[Rare] {name}");
        builder.SetDescription($"A rare {name} with enhanced healing");
        builder.SetWeight(1);
        builder.SetHealingPower(rareHealing);
        return builder.Build();
    }

    public QuestItem CreateQuestItem(string name, string description)
    {
        return new QuestItemBuilder(Guid.NewGuid().ToString())
            .SetName($"[Rare] {name}")
            .SetDescription(description)
            .SetWeight(1)
            .Build();
    }
}