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

    }

    public override void Eat(Food food)
    {
        // Cat-specific eating behavior
        string type = food.GetItemType();
        
        switch(type)
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

        // Aloofness level check and results here that interupt the playtime by the cat wandering off or something to that effect.

        // Similar to food check above, create specific responses to determined toy types, including CatnipToys increasing catnip level.
        string type = toy.GetItemType();
    }

    public override void Sleep()
    {
        // Cat-specific sleeping behavior

        // Decrease aloofness a bit here, lower catnip level
    }

    public override void MakeSound()
    {
        // Look into audio and add public domain sound effects here
        Console.WriteLine($"{_name} meows.");
    }
}