public class QuestItemBuilder : IItemBuilder<QuestItem>
{
    private string _id;
    private string _name = "Unknown Quest Item";
    private string _description = "A mysterious quest item";
    private int _weight = 1;

    public QuestItemBuilder(string id)
    {
        _id = id;
    }

    public IItemBuilder<QuestItem> SetName(string name)
    {
        _name = name;
        return this;
    }

    public IItemBuilder<QuestItem> SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public IItemBuilder<QuestItem> SetWeight(int weight)
    {
        _weight = weight;
        return this;
    }

    public QuestItem Build()
    {
        return new QuestItem(_id, _name, _description, _weight);
    }
}