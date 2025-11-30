// Models/Base/Item.cs
public abstract class Item : IItem
{
    public string Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Weight { get; protected set; }
    public abstract ItemType Type { get; }

    protected Item(string id, string name, string description, int weight)
    {
        Id = id;
        Name = name;
        Description = description;
        Weight = weight;
    }
}