public class EquippedState : IItemState
{
    public void HandleEquip(Item item)
    {
        Console.WriteLine($"{item.Name} is already equipped.");
    }

    public void HandleUse(Item item)
    {
        if (item is IUsable usable)
        {
            usable.Use();
        }
        else
        {
            Console.WriteLine($"{item.Name} cannot be used.");
        }
    }

    public void HandleDrop(Item item)
    {
        if (item is IEquipable equipable)
        {
            equipable.Unequip();
        }
        Console.WriteLine($"{item.Name} has been dropped.");
    }
}
