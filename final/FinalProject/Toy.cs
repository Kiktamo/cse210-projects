abstract class Toy : Item
{
    private double _durability;

    public Toy(string name, string type, double durability, double cost) : base(name,type,cost)
    {
        _durability = durability;
    }

    public abstract string Play();

    public bool IsBroken() 
    {
        return _durability <= 0; 
    }
}