public class EquipmentManager
{
    private readonly Dictionary<ItemType, Item> _equippedItems;

    public EquipmentManager()
    {
        _equippedItems = new Dictionary<ItemType, Item>();
    }

    public bool EquipItem(Item item)
    {
        if (item is not IEquipable equipable)
            return false;

        // Снимаем текущую экипировку этого типа
        if (_equippedItems.ContainsKey(item.Type))
        {
            var currentItem = _equippedItems[item.Type];
            if (currentItem is IEquipable currentEquipable)
            {
                currentEquipable.Unequip();
            }
        }

        equipable.Equip();
        _equippedItems[item.Type] = item;
        return true;
    }

    public void UnequipItem(ItemType type)
    {
        if (_equippedItems.ContainsKey(type))
        {
            var item = _equippedItems[type];
            if (item is IEquipable equipable)
            {
                equipable.Unequip();
            }
            _equippedItems.Remove(type);
        }
    }

    public void DisplayEquipment()
    {
        Console.WriteLine("Equipped Items:");
        Console.WriteLine("===============");
        
        foreach (var (type, item) in _equippedItems)
        {
            Console.WriteLine($"{type}: {item.Name}");
        }
    }

    public int GetTotalDefense()
    {
        return _equippedItems.Values
            .OfType<Armor>()
            .Sum(armor => armor.Defense);
    }

    public int GetTotalDamage()
    {
        return _equippedItems.Values
            .OfType<Weapon>()
            .Sum(weapon => weapon.Damage);
    }
}