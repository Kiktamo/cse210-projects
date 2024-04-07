using System;
using System.Collections.Generic;

class Game
{
    private Pet _pet;
    private double _cleanliness;
    private double _money;
    private List<Toy> _toys;
    private List<Food> _food;
    private bool _dev;

    public Game()
    {
        // Prompt the user to name and choose a color for their pet
        Console.Write("Enter a name for your pet: ");
        string petName = Console.ReadLine();
        Console.Write("Choose a color for your pet (e.g., 'black', 'white', 'brown'): ");
        string petColor = Console.ReadLine();

        // Create the pet based on user input
        // Just a cat for now, remember to add the choice later. As well as an option to load instead.
        _pet = new CatPet(petName, petColor);
        _cleanliness = 100; // Need some way of informing player of cleanliness maybe a log after menu options?
        _money = 50;
        _toys = new List<Toy>();
        _food = new List<Food>();

        // Small development option until I get more methods completed
        _dev = true;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine($"Pet: {_pet.GetName()}     Money: {Math.Round(_money, 2)}\nToys: {_toys.Count()}       Food: {_food.Count()}");
            Console.WriteLine("---------------");
            Console.WriteLine("Virtual Pet Game");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Feed Pet");
            Console.WriteLine("2. Play with Pet");
            Console.WriteLine("3. Put Pet to Sleep");
            Console.WriteLine("4. Clean Environment");
            Console.WriteLine("5. Display Pet Stats");
            Console.WriteLine("6. Shop");
            Console.WriteLine("7. Save");
            Console.WriteLine("8. Load");
            Console.WriteLine("9. Quit");
            if (_dev)
            {
                Console.WriteLine("10. Dev Menu");
            }
            Console.Write("Enter your choice (1-9): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    FeedPet();
                    break;
                case "2":
                    PlayWithPet();
                    break;
                case "3":
                    PutPetToSleep();
                    break;
                case "4":
                    CleanEnvironment();
                    break;
                case "5":
                    DisplayPetStats();
                    break;
                case "6":
                    Shop();
                    break;
                case "7":
                    Save();
                    break;
                case "8":
                    Load();
                    break;
                case "9":
                    running = false;
                    break;
                case "10":
                    DevMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            FinishTurn();
            Console.ReadLine();
        }
    }

    public void FeedPet()
    {
        // Display a list of available foods
        Console.WriteLine("Available Foods:");
        foreach (Food food in _food)
        {
            Console.WriteLine($"{food.GetName()} - Nutrition: {food.GetNutrition()}, Cost: {food.GetCost()}");
        }

        Console.Write("Enter the name of the food you want to feed your pet: ");
        string foodName = Console.ReadLine();

        // Find the selected food in the list and feed it to the pet
        Food selectedFood = _food.Find(f => f.GetName() == foodName);
        if (selectedFood != null)
        {
            _pet.Eat(selectedFood);
        }
        else
        {
            Console.WriteLine("That food is not available.");
        }
    }

    public void PlayWithPet()
    {
        // Display a list of available toys
        Console.WriteLine("Available Toys:");
        foreach (Toy toy in _toys)
        {
            Console.WriteLine($"{toy.GetName()} - Cost: {toy.GetCost()}");
        }

        Console.Write("Enter the name of the toy you want to play with your pet: ");
        string toyName = Console.ReadLine();

        // Find the selected toy in the list and play with the pet
        Toy selectedToy = _toys.Find(t => t.GetName() == toyName);
        if (selectedToy != null)
        {
            _pet.Play(selectedToy);
        }
        else
        {
            Console.WriteLine("That toy is not available.");
        }
    }

    public void PutPetToSleep()
    {
        _pet.Sleep();
        Console.WriteLine($"{_pet.GetName()} is now sleeping.");
    }

    public void CleanEnvironment()
    {
        _cleanliness = 100;
        Console.WriteLine("You have cleaned the pet's environment.");
    }

    public void DisplayPetStats()
    {
        _pet.DisplayStats();
        _pet.DisplayDescription();
    }

    public void Shop()
    {
        bool shopping = true;
        while (shopping)
        {
            Console.Clear();
            Console.WriteLine("Pet Store");
            Console.WriteLine("--------");
            Console.WriteLine("1. Buy Food");
            Console.WriteLine("2. Buy Toys");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BuyFood();
                    break;
                case "2":
                    BuyToys();
                    break;
                case "3":
                    shopping = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void BuyFood()
    {
        // Implement food purchasing logic
    }

    private void BuyToys()
    {
        // Implement toy purchasing logic
    }

    public void Save()
    {
        // Implement save game logic
        Console.WriteLine("Game saved.");
    }

    public void Load()
    {
        // Implement load game logic
        Console.WriteLine("Game loaded.");
    }

    public void DevMenu()
    {
        bool devMenu = true;
        while (devMenu)
        {
            Console.Clear();
            Console.WriteLine("Dev Menu");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Add Toys");
            Console.WriteLine("2. Add Food");
            Console.WriteLine("3. Exit Menu");
            Console.Write("Enter your choice (1-3): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _toys.Add(new BallToy("ball", 5.0, 5.0, false, false));
                    _toys.Add(new ChewToy("chewToy", 5.0, 5.0, 0.5));
                    _toys.Add(new CatnipToy("catnipToy", 5.0, 5.0, 10));
                    break;
                case "2":
                    _food.Add(new Food("Cat Food", "CatFood", 5.0, 5.0));
                    _food.Add(new Food("Salmon", "Fish", 5.5, 5.0));
                    _food.Add(new Food("Meat", "Meat", 10.0, 5.0));
                    break;
                case "3":
                    devMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            } 
        }
    }
    private void FinishTurn()
    {
        // Update money, remove broken toys and eaten foods
        _pet.DoTurn();
        _money += _pet.GetHappiness() * _pet.GetMoneyModifier() * 0.1;
        _toys.RemoveAll(t => t.IsBroken());
        _food.RemoveAll(f => f.IsEaten());
    }
}