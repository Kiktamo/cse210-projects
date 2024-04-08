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
        _toys = new List<Toy>();
        _food = new List<Food>();
        // Create the pet based on user input, or load an existing save
        Console.Write("Do you want to load an existing save? (y/n) ");
        string loadChoice = Console.ReadLine();
        if (loadChoice.ToLower() == "y")
        {
            Load();
        }
        else
        {
            // Prompt the user to name and choose a pet type
            Console.Write("Enter a name for your pet: ");
            string petName = Console.ReadLine();
            Console.Write("Choose a pet type (1 for Cat, 2 for Dog): ");
            int petType = int.Parse(Console.ReadLine());

            Console.Write("Choose a color for your pet (e.g., 'black', 'white', 'brown'): ");
            string petColor = Console.ReadLine();

            if (petType == 1)
            {
                _pet = new CatPet(petName, petColor);
            }
            else
            {
                _pet = new DogPet(petName, petColor);
            }

            _cleanliness = 100;
            _money = 50;
        }

        // Small development option until I get more methods completed
        _dev = false;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine($"Pet: {_pet.GetName()}     Money: {Math.Round(_money, 2)}");
            Console.WriteLine($"Toys: {_toys.Count()}       Food: {_food.Count()}     Cleanliness: {Math.Round(_cleanliness, 2)}%");
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
        Console.WriteLine("Available Food:");

        // Generate a list of random food items
        List<Food> foodItems = GenerateFoodItems();

        // Display the food items and allow the user to purchase
        foreach (Food food in foodItems)
        {
            Console.WriteLine($"{food.GetName()} - Nutrition: {food.GetNutrition()}, Cost: {food.GetCost()}");
        }

        Console.Write("Enter the name of the food you want to buy: ");
        string foodName = Console.ReadLine();

        // Find the selected food in the list and purchase it
        Food selectedFood = foodItems.Find(f => f.GetName() == foodName);
        if (selectedFood != null)
        {
            if (_money >= selectedFood.GetCost())
            {
                _food.Add(selectedFood);
                _money -= selectedFood.GetCost();
                Console.WriteLine($"You bought {selectedFood.GetName()} for {selectedFood.GetCost()}.");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy that food.");
            }
        }
        else
        {
            Console.WriteLine("That food is not available.");
        }
    }

    private void BuyToys()
    {
        Console.WriteLine("Available Toys:");

        // Generate a list of random toy items
        List<Toy> toyItems = GenerateToyItems();

        // Display the toy items and allow the user to purchase
        foreach (Toy toy in toyItems)
        {
            Console.WriteLine($"{toy.GetName()} - Cost: {toy.GetCost()}");
        }

        Console.Write("Enter the name of the toy you want to buy: ");
        string toyName = Console.ReadLine();

        // Find the selected toy in the list and purchase it
        Toy selectedToy = toyItems.Find(t => t.GetName() == toyName);
        if (selectedToy != null)
        {
            if (_money >= selectedToy.GetCost())
            {
                _toys.Add(selectedToy);
                _money -= selectedToy.GetCost();
                Console.WriteLine($"You bought {selectedToy.GetName()} for {selectedToy.GetCost()}.");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy that toy.");
            }
        }
        else
        {
            Console.WriteLine("That toy is not available.");
        }
    }

    private List<Food> GenerateFoodItems()
    {
        List<Food> foodItems = new List<Food>();

        // Predifined for now might create randoms if I have more time
        foodItems.Add(new Food("Premium Kibble", "DogFood", 10.0, 8.99));
        foodItems.Add(new Food("Savory Tuna Bites", "Fish", 8.0, 6.99));
        foodItems.Add(new Food("Hearty Beef Chunks", "Meat", 12.0, 9.99));

        return foodItems;
    }

    private List<Toy> GenerateToyItems()
    {
        List<Toy> toyItems = new List<Toy>();

        // Predifined for now might create randoms if I have more time
        toyItems.Add(new BallToy("Squeaky Ball", 20.0, 4.99, true, false));
        toyItems.Add(new ChewToy("Tough Rope Toy", 25.0, 6.99, 0.8));
        toyItems.Add(new CatnipToy("Catnip-Infused Mouse", 15.0, 5.99, 15));

        return toyItems;
    }

    public void Save()
    {
        Console.Write("Enter a file name to save the game: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter($"{fileName}.txt"))
            {
                writer.WriteLine(_pet.GetPetType());
                writer.WriteLine(_pet.GetName());
                writer.WriteLine(_pet.GetHealth());
                writer.WriteLine(_pet.GetHappiness());
                writer.WriteLine(_pet.GetHunger());
                writer.WriteLine(_pet.GetEnergy());
                writer.WriteLine(_pet.GetColor());
                writer.WriteLine(_cleanliness);
                writer.WriteLine(_money);

                // Save the toy and food lists
                writer.WriteLine(_toys.Count);
                foreach (Toy toy in _toys)
                {
                    writer.WriteLine($"{toy.GetName()};{toy.GetItemType()};{toy.GetDurability()};{toy.GetCost()}");
                }
                writer.WriteLine(_food.Count);
                foreach (Food food in _food)
                {
                    writer.WriteLine($"{food.GetName()};{food.GetItemType()};{food.GetNutrition()};{food.GetCost()}");
                }
            }

            Console.WriteLine("Game saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the game: {ex.Message}");
        }
    }

    public void Load()
    {
        Console.Write("Enter the file name to load the game: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader($"{fileName}.txt"))
            {
                string petType = reader.ReadLine();
                string petName = reader.ReadLine();
                double petHealth = double.Parse(reader.ReadLine());
                double petHappiness = double.Parse(reader.ReadLine());
                double petHunger = double.Parse(reader.ReadLine());
                double petEnergy = double.Parse(reader.ReadLine());
                string petColor = reader.ReadLine();
                _cleanliness = double.Parse(reader.ReadLine());
                _money = double.Parse(reader.ReadLine());

                // Added for loading at the start.
                if (petType == "Cat")
                {
                    _pet = new CatPet(petName);
                }
                else
                {
                    _pet = new DogPet(petName);
                }
                // Currently the Cats unique stats are not saved or loaded, might rework for that if there's time.
                _pet.LoadStats(petName, petHealth, petHappiness, petHunger, petEnergy, petColor);


                // Load the toy and food lists
                int toyCount = int.Parse(reader.ReadLine());
                _toys.Clear();
                for (int i = 0; i < toyCount; i++)
                {
                    string[] toyData = reader.ReadLine().Split(';');
                    string toyName = toyData[0];
                    string toyType = toyData[1];
                    double toyDurability = double.Parse(toyData[2]);
                    double toyCost = double.Parse(toyData[3]);

                    if (toyType == "ball")
                    {
                        _toys.Add(new BallToy(toyName, toyDurability, toyCost, false, false));
                    }
                    else if (toyType == "chewToy")
                    {
                        _toys.Add(new ChewToy(toyName, toyDurability, toyCost, 1.0));
                    }
                    else if (toyType == "catnipToy")
                    {
                        _toys.Add(new CatnipToy(toyName, toyDurability, toyCost, 10));
                    }
                }

                int foodCount = int.Parse(reader.ReadLine());
                _food.Clear();
                for (int i = 0; i < foodCount; i++)
                {
                    string[] foodData = reader.ReadLine().Split(';');
                    string foodName = foodData[0];
                    string foodType = foodData[1];
                    double foodNutrition = double.Parse(foodData[2]);
                    double foodCost = double.Parse(foodData[3]);

                    _food.Add(new Food(foodName, foodType, foodNutrition, foodCost));
                }

                Console.WriteLine("Game loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the game: {ex.Message}");
        }
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
                    _toys.Add(new BallToy("Generic Ball", 5.0, 5.0, false, false));
                    _toys.Add(new ChewToy("Generic ChewToy", 5.0, 5.0, 0.5));
                    _toys.Add(new CatnipToy("Generic CatnipToy", 5.0, 5.0, 10));
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