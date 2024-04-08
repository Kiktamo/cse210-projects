class ChewToy : Toy
{
    private double _durabilityMod;

    public ChewToy(string name, double durability, double cost, double durabilityMod) : base(name, "chewToy", durability, cost)
    {
        _durabilityMod = durabilityMod;
    }

    public override string Play()
    {
        DecreaseDurability(1 * _durabilityMod);
        return $"The pet chews on the {_name}.";
    }
}