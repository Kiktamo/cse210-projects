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
        DecreaseDurability(1); 
        string play = $"You play with your pet using {GetName()}.";
        if (_hasBells)
        {
            play += "\nThe bells jingle and jangle all over the place.";
        }
        if (_hasSqueaker)
        {
            play += "\nIt squeaks many times as you play.";
        }

        return play;
    }
}