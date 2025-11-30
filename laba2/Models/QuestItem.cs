public class QuestItem : Item
{
    public override ItemType Type => ItemType.Quest;

    public QuestItem(string id, string name, string description, int weight) 
        : base(id, name, description, weight)
    {
    }
}