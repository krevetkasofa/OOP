public class ArmorBuilder : IItemBuilder<Armor>
{
    private string _id;
    private string _name = "Unknown Armor";
    private string _description = "A basic armor";
    private int _weight = 5;
    private int _defense = 5;

    public ArmorBuilder(string id)
    {
        _id = id;
    }

    public IItemBuilder<Armor> SetName(string name)
    {
        _name = name;
        return this;
    }

    public IItemBuilder<Armor> SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public IItemBuilder<Armor> SetWeight(int weight)
    {
        _weight = weight;
        return this;
    }

    public ArmorBuilder SetDefense(int defense)
    {
        _defense = defense;
        return this;
    }

    public Armor Build()
    {
        return new Armor(_id, _name, _description, _weight, _defense);
    }
}