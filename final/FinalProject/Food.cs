class Food : Item
{
    private double _nutrition;
    private bool _eaten;

    public Food(string name, string type, double nutrition, double cost) : base(name,type,cost)
    {
        _nutrition = nutrition;
        _eaten = false;
    }

    public double GetNutrition() 
    { 
        return _nutrition; 
    }

    public string Eat() 
    { 
        _eaten = true;

        return $"You feed {_name} to your pet."; 
    }

    public bool IsEaten() 
    { 
        return _eaten; 
    }
}