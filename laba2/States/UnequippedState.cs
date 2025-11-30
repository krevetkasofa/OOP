public class UnequippedState : IItemState
{
    public void HandleEquip(Item item)
    {
        if (item is IEquipable equipable)
        {
            equipable.Equip();
            Console.WriteLine($"{item.Name} has been equipped.");
        }
        else
        {
            Console.WriteLine($"{item.Name} cannot be equipped.");
        }
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
        Console.WriteLine($"{item.Name} has been dropped.");
    }
}