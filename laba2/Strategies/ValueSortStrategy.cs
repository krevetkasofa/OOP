public class ValueSortStrategy : ISortStrategy
{
    public IEnumerable<Item> Sort(IEnumerable<Item> items)
    {
        return items.OrderByDescending(item =>
        {
            return item switch
            {
                Weapon weapon => weapon.Damage,
                Armor armor => armor.Defense,
                Potion potion => potion.HealingPower,
                _ => 0
            };
        });
    }
}