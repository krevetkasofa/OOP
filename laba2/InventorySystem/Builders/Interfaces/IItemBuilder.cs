public interface IItemBuilder<T> where T : Item
{
    IItemBuilder<T> SetName(string name);
    IItemBuilder<T> SetDescription(string description);
    IItemBuilder<T> SetWeight(int weight);
    T Build();
}

