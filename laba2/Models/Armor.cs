public class Armor : Item, IEquipable, IUpgradable
{
    public int Defense { get; private set; }
    public bool IsEquipped { get; private set; }
    public int Level { get; private set; }
    public override ItemType Type => ItemType.Armor;

    public Armor(string id, string name, string description, int weight, int defense) 
        : base(id, name, description, weight)
    {
        Defense = defense;
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
        Defense = (int)(Defense * 1.15);
    }
}