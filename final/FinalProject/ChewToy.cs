class ChewToy : Toy
{
    private double _durabilityMod;

    public ChewToy(string name, double durability, double cost, double durabilityMod) : base(name, "ChewToy", durability, cost)
    {
        _durabilityMod = durabilityMod;
    }

    public override string Play() 
    { 
        return $"The pet chews on the {_name}.";
        // Lower durability with modifer impacting amount
    }
}