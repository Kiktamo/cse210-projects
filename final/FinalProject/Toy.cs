abstract class Toy : Item
{
    private double _durability;

    public Toy(string name, string type, double durability, double cost) : base(name, type, cost)
    {
        _durability = durability;
    }

    public abstract string Play();

    public double GetDurability()
    {
        return _durability;
    }

    public void DecreaseDurability(double value)
    {
        _durability = Math.Clamp(_durability - value, 0, 100);
    }

    public bool IsBroken()
    {
        return _durability <= 0;
    }
}