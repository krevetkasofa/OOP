public class WeaponBuilder : IItemBuilder<Weapon>
{
    private string _id;
    private string _name = "Unknown Weapon";
    private string _description = "A basic weapon";
    private int _weight = 1;
    private int _damage = 10;

    public WeaponBuilder(string id)
    {
        _id = id;
    }

    public IItemBuilder<Weapon> SetName(string name)
    {
        _name = name;
        return this;
    }

    public IItemBuilder<Weapon> SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public IItemBuilder<Weapon> SetWeight(int weight)
    {
        _weight = weight;
        return this;
    }

    public WeaponBuilder SetDamage(int damage)
    {
        _damage = damage;
        return this;
    }

    public Weapon Build()
    {
        return new Weapon(_id, _name, _description, _weight, _damage);
    }
}