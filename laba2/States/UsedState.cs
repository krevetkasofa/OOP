public class UsedState : IItemState
{
    public void HandleEquip(Item item)
    {
        Console.WriteLine($"{item.Name} has been used and cannot be equipped.");
    }

    public void HandleUse(Item item)
    {
        Console.WriteLine($"{item.Name} has already been used.");
    }

    public void HandleDrop(Item item)
    {
        Console.WriteLine($"{item.Name} has been used and dropped.");
    }
}