abstract class Item
{
    protected string _name;
    protected string _type;
    protected double _cost;

    public Item(string name, string type, double cost)
    {
        _name = name;
        _type = type;
        _cost = cost;
    }

    public string GetItemType()
    {
        return _type;
    }
    public string GetName()
    {
        return _name;
    }

    public double GetCost()
    {
        return _cost;
    }

    public void SetName(string name)
    {
        _name = name;
    }
}