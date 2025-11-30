public interface IItemState
{
    void HandleEquip(Item item);
    void HandleUse(Item item);
    void HandleDrop(Item item);
}

