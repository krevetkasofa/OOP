public interface ISortStrategy
{
    IEnumerable<Item> Sort(IEnumerable<Item> items);
}