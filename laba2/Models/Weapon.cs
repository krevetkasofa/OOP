public class Weapon : Item, IEquipable, IUpgradable
{
    public int Damage { get; private set; }
    public bool IsEquipped { get; private set; }
    public int Level { get; private set; }
    public override ItemType Type => ItemType.Weapon;

    public Weapon(string id, string name, string description, int weight, int damage) 
        : base(id, name, description, weight)
    {
        Damage = damage;
        Level = 1;
        IsEquipped = false;
    }

    public void Equip()
    {
        IsEquipped = true;
    }

    public void Unequip()
    {
        IsEquipped = false;
    }
    
    public void Upgrade()
    {
        Level++;
        Damage = (int)(Damage * 1.2);
    }
}