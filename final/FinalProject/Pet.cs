abstract class Pet
{
    protected string _name;
    protected double _health;
    protected double _happiness;
    protected double _hunger;
    protected double _energy;
    protected string _color;

    public Pet(string name)
    {
        _name = name;
        _health = 100;
        _happiness = 100;
        _hunger = 0;
        _energy = 100;
    }

    public Pet(string name, string color)
    {
        _name = name;
        _color = color;
        _health = 100;
        _happiness = 100;
        _hunger = 0;
        _energy = 100;
    }

    public abstract void Eat(Food food);
    public abstract void Play(Toy toy);
    public abstract void Sleep();
    public abstract void MakeSound();
    public void DisplayStats()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Happiness: {_happiness}");
        Console.WriteLine($"Hunger: {_hunger}");
        Console.WriteLine($"Energy: {_energy}");
    }
    public virtual void DisplayDescription()
    {
        Console.WriteLine($"You see {_name} and their {_color} fur.");
    }
    public void LoadStats(string name, double health, double happiness, double hunger, double energy, string color)
    {
        _name = name;
        _health = health;
        _happiness = happiness;
        _hunger = hunger;
        _energy = energy;
        _color = color;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetHappiness()
    {
        return _happiness;
    }
}