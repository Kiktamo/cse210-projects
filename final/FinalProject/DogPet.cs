class DogPet : Pet
{
    public DogPet(string name) : base(name) { }
    public DogPet(string name, string color) : base(name, color) { }

    public override void Eat(Food food)
    {
        // Dog-specific eating behavior
    }

    public override void Play(Toy toy)
    {
        // Dog-specific playing behavior
    }

    public override void Sleep()
    {
        // Dog-specific sleeping behavior
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{_name} barks.");
    }
}