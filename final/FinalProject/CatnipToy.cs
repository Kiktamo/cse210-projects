class CatnipToy : Toy
{
    private int _catnipLevel;

    public CatnipToy(string name, double durability, double cost, int catnipLevel) : base(name, "catnipToy", durability, cost)
    {
        _catnipLevel = catnipLevel;
    }

    public int GetCatnipLevel()
    {
        return _catnipLevel;
    }

    public override string Play() 
    {
        DecreaseDurability(1);
        return "You play with your pet using the catnip toy."; 
    }

    public int UseCatnip() 
    {
        if (_catnipLevel != 0)
        {
            _catnipLevel -= 1;
            return 1; 
        }
        else
        {
            return 0;
        }

    }
}