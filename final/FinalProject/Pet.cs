abstract class Pet
{
    protected string _name;
    protected double _health;
    protected double _happiness;
    protected double _hunger;
    protected double _energy;
    protected string _color;

    protected string _petType;

    public Pet(string name)
    {
        _name = name;
        _health = 100;
        _happiness = 100;
        _hunger = 0;
        _energy = 100;
        _petType = "Pet";
    }

    public Pet(string name, string color)
    {
        _name = name;
        _color = color;
        _health = 100;
        _happiness = 100;
        _hunger = 0;
        _energy = 100;
        _petType = "Pet";
    }

    public string GetName()
    {
        return _name;
    }

    public double GetHappiness()
    {
        return _happiness;
    }

    public string GetColor()
    {
        return _color;
    }

    public double GetHealth()
    {
        return _health;
    }

    public double GetEnergy()
    {
        return _energy;
    }

    public double GetHunger()
    {
        return _hunger;
    }

    public string GetPetType()
    {
        return _petType;
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

    public virtual void DoTurn()
    {
        // Decrease hunger and energy slightly over time
        _hunger += 1;
        _energy -= 2;

        // Increase hunger if energy is low
        if (_energy < 50)
        {
            _hunger += 1;
        }

        // Decrease happiness if hunger or energy is too low
        if (_hunger > 80 || _energy < 20)
        {
            _happiness -= 5;
        }
        else
        {
            // Increase happiness slightly if pet is in a good state
            _happiness += 1;
        }

        // Decrease health if happiness is too low
        if (_happiness < 50)
        {
            _health -= 2;
        }
        else
        {
            // Increase health slightly if pet is happy
            _health += 1;
        }

        // Clamp all values to their valid ranges
        _health = Math.Clamp(_health, 0, 100);
        _happiness = Math.Clamp(_happiness, 0, 100);
        _hunger = Math.Clamp(_hunger, 0, 100);
        _energy = Math.Clamp(_energy, 0, 100);
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


    public double GetMoneyModifier()
    {
        double moneyModifier = 0;

        // Happiness modifier
        moneyModifier += _happiness * 0.1;

        // Health modifier
        if (_health >= 80)
        {
            moneyModifier += 0.2; // 20% bonus if pet is healthy
        }
        else if (_health >= 50)
        {
            moneyModifier += 0.1; // 10% bonus if pet is somewhat healthy
        }

        // Hunger modifier
        if (_hunger <= 20)
        {
            moneyModifier += 0.15; // 15% bonus if pet is well-fed
        }
        else if (_hunger <= 50)
        {
            moneyModifier += 0.05; // 5% bonus if pet is somewhat well-fed
        }
        else
        {
            moneyModifier -= 0.1; // 10% penalty if pet is hungry
        }

        // Energy modifier
        if (_energy >= 80)
        {
            moneyModifier += 0.15; // 15% bonus if pet is well-rested
        }
        else if (_energy >= 50)
        {
            moneyModifier += 0.05; // 5% bonus if pet is somewhat well-rested
        }
        else
        {
            moneyModifier -= 0.1; // 10% penalty if pet is tired
        }

        return Math.Clamp(moneyModifier, 0, 2); // Ensure the modifier is between 0 and 2
    }
}