public class PotionBuilder : IItemBuilder<Potion>
{
    private string _id;
    private string _name = "Unknown Potion";
    private string _description = "A basic potion";
    private int _weight = 1;
    private int _healingPower = 20;

    public PotionBuilder(string id)
    {
        _id = id;
    }

    public IItemBuilder<Potion> SetName(string name)
    {
        _name = name;
        return this;
    }

    public IItemBuilder<Potion> SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public IItemBuilder<Potion> SetWeight(int weight)
    {
        _weight = weight;
        return this;
    }

    public PotionBuilder SetHealingPower(int healingPower)
    {
        _healingPower = healingPower;
        return this;
    }

    public Potion Build()
    {
        return new Potion(_id, _name, _description, _weight, _healingPower);
    }
}