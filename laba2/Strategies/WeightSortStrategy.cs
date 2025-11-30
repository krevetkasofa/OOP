public class WeightSortStrategy : ISortStrategy
{
    public IEnumerable<Item> Sort(IEnumerable<Item> items)
    {
        return items.OrderBy(item => item.Weight);
    }
}