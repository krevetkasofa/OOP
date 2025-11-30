public class CommonItemFactory : IItemFactory
{
    public Weapon CreateWeapon(string name, int baseDamage)
    {
        var builder = new WeaponBuilder(Guid.NewGuid().ToString());
        builder.SetName(name);
        builder.SetDescription($"A common {name}");
        builder.SetWeight(3);
        builder.SetDamage(baseDamage);
        return builder.Build();
    }

    public Armor CreateArmor(string name, int baseDefense)
    {
        var builder = new ArmorBuilder(Guid.NewGuid().ToString());
        builder.SetName(name);
        builder.SetDescription($"A common {name}");
        builder.SetWeight(8);
        builder.SetDefense(baseDefense);
        return builder.Build();
    }

    public Potion CreatePotion(string name, int healingPower)
    {
        var builder = new PotionBuilder(Guid.NewGuid().ToString());
        builder.SetName(name);
        builder.SetDescription($"A common {name}");
        builder.SetWeight(1);
        builder.SetHealingPower(healingPower);
        return builder.Build();
    }

    public QuestItem CreateQuestItem(string name, string description)
    {
        return new QuestItemBuilder(Guid.NewGuid().ToString())
            .SetName(name)
            .SetDescription(description)
            .SetWeight(1)
            .Build();
    }
}