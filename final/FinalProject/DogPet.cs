class DogPet : Pet
{
    public DogPet(string name) : base(name)
    {
        _petType = "Dog";
    }

    public DogPet(string name, string color) : base(name, color)
    {
        _petType = "Dog";
    }

    public override void Eat(Food food)
    {
        // Dog-specific eating behavior
        string type = food.GetItemType();
        switch (type)
        {
            case "Meat":
                food.Eat();
                Console.WriteLine($"{_name} eagerly devours the meat.");
                _happiness += 2;
                _hunger -= food.GetNutrition() * 1.5;
                break;
            case "DogFood":
                food.Eat();
                Console.WriteLine($"{_name} happily eats the dog food.");
                _happiness++;
                _hunger -= food.GetNutrition() * 1.25;
                break;
            default:
                food.Eat();
                Console.WriteLine($"{_name} seems to enjoy the food.");
                _hunger -= food.GetNutrition();
                break;
        }
    }

    public override void Play(Toy toy)
    {
        // Dog-specific playing behavior
        toy.Play();
        string type = toy.GetItemType();
        switch (type)
        {
            case "Ball":
                Console.WriteLine($"{_name} chases after the ball and brings it back.");
                _happiness += 2;
                _energy += 3;
                break;
            case "ChewToy":
                Console.WriteLine($"{_name} enthusiastically chews on the toy.");
                _happiness += 1;
                _energy += 2;
                break;
            default:
                Console.WriteLine($"{_name} seems somewhat interested in the {toy.GetName()}, but doesn't quite understand it.");
                _happiness += 1;
                _energy += 1;
                break;
        }
    }

    public override void Sleep()
    {
        // Dog-specific sleeping behavior
        _happiness += 1;
        _energy = 100;
        Console.WriteLine($"{_name} takes a relaxing nap.");
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{_name} barks.");
    }
}