public class NameSortStrategy : ISortStrategy
{
    public IEnumerable<Item> Sort(IEnumerable<Item> items)
    {
        return items.OrderBy(item => item.Name);
    }
}