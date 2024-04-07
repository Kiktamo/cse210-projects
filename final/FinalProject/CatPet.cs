using System.Diagnostics;

class CatPet : Pet
{
    private int _catnipLevel;
    private int _aloofnessLevel;

    public CatPet(string name) : base(name)
    {
        _catnipLevel = 0;
        _aloofnessLevel = 0;
    }

    public CatPet(string name, string color) : base(name, color)
    {
        _catnipLevel = 0;
        _aloofnessLevel = 0;
    }

    public override void Eat(Food food)
    {
        // Cat-specific eating behavior
        string type = food.GetItemType();
        switch (type)
        {
            case "Fish":
                food.Eat();
                Console.WriteLine($"{_name} seems particularly happy with this food.");
                _happiness += 2;
                _hunger -= food.GetNutrition() * 1.25;
                break;
            case "Meat":
                food.Eat();
                Console.WriteLine($"{_name} seems fairly happy with this food.");
                _happiness++;
                _hunger -= food.GetNutrition() * 1.1;
                break;
            case "CatFood":
                food.Eat();
                Console.WriteLine($"{_name} seems okay with this food.");
                _happiness += 0.5;
                _hunger -= food.GetNutrition();
                break;
            default:
                food.Eat();
                Console.WriteLine($"{_name} seems to tolerate this food.");
                _hunger -= food.GetNutrition();
                break;
        }
    }

    public override void Play(Toy toy)
    {
        // Cat-specific playing behavior
        Random random = new Random();
        if (random.NextDouble() < (_aloofnessLevel / 100.0))
        {
            Console.WriteLine($"{_name} decides to wander off and ignore the {toy.GetName()}.");
            return;
        }

        string type = toy.GetItemType();
        switch (type)
        {
            case "ball":
                Console.WriteLine($"{_name} playfully bats at the ball.");
                _happiness += 1;
                _energy += 2;
                break;
            case "chewToy":
                Console.WriteLine($"{_name} enthusiastically chews on the toy.");
                _happiness += 1;
                _energy += 1;
                break;
            case "catnipToy":
                int catnipGain = ((CatnipToy)toy).UseCatnip();
                _catnipLevel += catnipGain;
                Console.WriteLine($"{_name} goes wild over the catnip toy.");
                _happiness += 2;
                _energy += 3;
                break;
            default:
                Console.WriteLine($"{_name} seems uninterested in the {toy.GetItemType()}.");
                break;
        }
    }

    public override void Sleep()
    {
        // Cat-specific sleeping behavior
        _aloofnessLevel -= 2;
        _catnipLevel = Math.Max(_catnipLevel - 5, 0);
        _happiness += 1;
        _energy = 100;
        Console.WriteLine($"{_name} takes a nice long nap.");
    }

    public override void MakeSound()
    {
        // Look into audio and add public domain sound effects here
        Console.WriteLine($"{_name} meows.");
    }

    public override void DoTurn()
    {
        Random random = new Random();

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

        // Modify behavior based on catnip and aloofness levels
        if (_catnipLevel > 50)
        {
            // Catnip-induced behavior
            _aloofnessLevel += random.Next(1, 5);
            _energy += 2;
            _happiness += 2;
        }
        else if (_aloofnessLevel > 50)
        {
            // Aloof behavior
            if (random.NextDouble() < (_aloofnessLevel / 100.0))
            {
                Console.WriteLine($"{_name} decides to wander off and ignore everything.");
                return;
            }
        }

        // Clamp all values to their valid ranges
        _health = Math.Clamp(_health, 0, 100);
        _happiness = Math.Clamp(_happiness, 0, 100);
        _hunger = Math.Clamp(_hunger, 0, 100);
        _energy = Math.Clamp(_energy, 0, 100);
        _catnipLevel = Math.Clamp(_catnipLevel, 0, 100);
        _aloofnessLevel = Math.Clamp(_aloofnessLevel, 0, 100);
    }
}