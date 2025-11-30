public class Inventory
{
    private readonly List<Item> _items;
    private readonly Dictionary<string, IItemState> _itemStates;
    private ISortStrategy _sortStrategy;

    public int Capacity { get; private set; }
    public int CurrentWeight => _items.Sum(item => item.Weight);
    public IEnumerable<Item> Items => _items.AsReadOnly();

    public Inventory(int capacity = 100)
    {
        _items = new List<Item>();
        _itemStates = new Dictionary<string, IItemState>();
        _sortStrategy = new NameSortStrategy();
        Capacity = capacity;
    }

    public void SetSortStrategy(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }

    public bool AddItem(Item item)
    {
        if (CurrentWeight + item.Weight > Capacity)
        {
            Console.WriteLine("Inventory is full!");
            return false;
        }

        _items.Add(item);
        _itemStates[item.Id] = new UnequippedState(); // Начальное состояние
        Console.WriteLine($"{item.Name} added to inventory.");
        return true;
    }

    public bool RemoveItem(string itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            _items.Remove(item);
            _itemStates.Remove(itemId);
            Console.WriteLine($"{item.Name} removed from inventory.");
            return true;
        }
        return false;
    }

    public void EquipItem(string itemId)
    {
        if (_itemStates.ContainsKey(itemId))
        {
            var item = _items.First(i => i.Id == itemId);
            _itemStates[itemId].HandleEquip(item);
            
            if (item is IEquipable equipable && equipable.IsEquipped)
            {
                _itemStates[itemId] = new EquippedState();
            }
        }
    }

    public void UseItem(string itemId)
    {
        if (_itemStates.ContainsKey(itemId))
        {
            var item = _items.First(i => i.Id == itemId);
            _itemStates[itemId].HandleUse(item);
            
            if (item is Potion)
            {
                _itemStates[itemId] = new UsedState();
                // Зелья исчезают после использования
                RemoveItem(itemId);
            }
        }
    }

    public void DropItem(string itemId)
    {
        if (_itemStates.ContainsKey(itemId))
        {
            var item = _items.First(i => i.Id == itemId);
            _itemStates[itemId].HandleDrop(item);
            RemoveItem(itemId);
        }
    }

    public void DisplayInventory()
    {
        var sortedItems = _sortStrategy.Sort(_items);
        
        Console.WriteLine($"Inventory (Weight: {CurrentWeight}/{Capacity}):");
        Console.WriteLine("=====================================");
        
        foreach (var item in sortedItems)
        {
            var state = _itemStates[item.Id];
            var stateInfo = state switch
            {
                EquippedState => "[EQUIPPED]",
                UsedState => "[USED]",
                _ => ""
            };

            var itemInfo = item switch
            {
                Weapon weapon => $"{weapon.Name} - Damage: {weapon.Damage}, Level: {weapon.Level}",
                Armor armor => $"{armor.Name} - Defense: {armor.Defense}, Level: {armor.Level}",
                Potion potion => $"{potion.Name} - Healing: {potion.HealingPower}",
                _ => item.Name
            };

            Console.WriteLine($"{itemInfo} {stateInfo}");
        }
    }

    public Item FindItem(string itemId)
    {
        return _items.FirstOrDefault(item => item.Id == itemId);
    }

    public IEnumerable<Item> GetItemsByType(ItemType type)
    {
        return _items.Where(item => item.Type == type);
    }
}