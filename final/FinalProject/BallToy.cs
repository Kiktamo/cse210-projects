class BallToy : Toy
{
    private bool _hasBells;
    private bool _hasSqueaker;

    public BallToy(string name, double durability, double cost, bool hasBells, bool hasSqueaker) : base(name, "Ball", durability, cost)
    {
        _hasBells = hasBells;
        _hasSqueaker = hasSqueaker;
    }

    public override string Play() 
    { 
        return $"You play with your pet using {_name}."; 
    }
}