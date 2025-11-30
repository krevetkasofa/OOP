public class Potion : Item, IUsable
{
    public int HealingPower { get; private set; }
    public override ItemType Type => ItemType.Potion;

    public Potion(string id, string name, string description, int weight, int healingPower) 
        : base(id, name, description, weight)
    {
        HealingPower = healingPower;
    }

    public void Use()
    {
        Console.WriteLine($"Used {Name}. Healed {HealingPower} HP.");
    }
}