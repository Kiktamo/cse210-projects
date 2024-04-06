class CatnipToy : Toy
{
    private int _catnipLevel;

    public CatnipToy(string name, double durability, double cost, int catnipLevel) : base(name, "CatnipToy", durability, cost)
    {
        _catnipLevel = catnipLevel;
    }

    public override string Play() 
    {
        // Not sure about this particular output.
        return "You play with your pet using the catnip toy."; 
    }

    public int DecreaseCatnip() 
    {
        // A more random number might be a good idea?
        --_catnipLevel;
        return 1; 
    }
}