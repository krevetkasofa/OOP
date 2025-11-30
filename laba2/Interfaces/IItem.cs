// Interfaces/IItem.cs
public interface IItem
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    int Weight { get; }
    ItemType Type { get; }
}

