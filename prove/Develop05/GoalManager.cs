using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private Player _player;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _player = new Player(0);
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine($"\nYou have {_player.GetScore()} points.");
            Console.WriteLine($"Your current rank is {_player.GetRank()}.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create a New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("\t1. Simple Goal - A basic goal that you complete once.");
        Console.WriteLine("\t2. Eternal Goal - A goal that is never truly complete.");
        Console.WriteLine("\t3. Checklist Goal - A goal that is completed a certain number of times before being done.");
        Console.WriteLine("\t4. Negative Goal - A goal to avoid something that subtracts points whenever completed.");
        Console.WriteLine("\t5. Alternating Goal - Two goals that switch between each other anytime they're completed.");
        Console.Write("Which type of goal would you like to create: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                CreateSimpleGoal();
                break;
            case "2":
                CreateEternalGoal();
                break;
            case "3":
                CreateChecklistGoal();
                break;
            case "4":
                CreateNegativeGoal();
                break;
            case "5":
                CreateAlternatingGoal();
                break;
            default:
                Console.WriteLine("Invalid choice. No goal created.");
                break;
        }
    }

    private void CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        _goals.Add(new SimpleGoal(name, description, points));
        Console.WriteLine("Goal created successfully.");
    }

    private void CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        _goals.Add(new EternalGoal(name, description, points));
        Console.WriteLine("Goal created successfully.");
    }

    private void CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("What is the target count for this goal? ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus points for completing this goal? ");
        int bonus = int.Parse(Console.ReadLine());

        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        Console.WriteLine("Goal created successfully.");
    }

    private void CreateNegativeGoal()
    {
        Console.Write("What is the name of your negative goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        _goals.Add(new NegativeGoal(name, description, points));
        Console.WriteLine("Goal created successfully.");
    }

    private void CreateAlternatingGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your alternate goal? ");
        string altName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string altDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int altPoints = int.Parse(Console.ReadLine());

        _goals.Add(new AlternatingGoal(name, description, points, altName, altDescription, altPoints));
        Console.WriteLine("Goal created successfully.");
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= _goals.Count)
        {
            if (!_goals[choice - 1].IsComplete())
            {
                int pointsEarned = _goals[choice - 1].RecordEvent();
                _player.AddScore(pointsEarned);
                Congratulate(choice - 1, pointsEarned);
            }
            else
            {
                Console.WriteLine("That goal is already complete.");
            }

        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void Congratulate(int goalIndex, int pointsEarned)
    {
        string goalType = _goals[goalIndex].GetType().Name;

        switch(goalType)
        {
            case "SimpleGoal":
                Console.WriteLine($"You completed another goal and earned {pointsEarned} points! Your current score is {_player.GetScore()}.");
                break;
            case "EternalGoal":
                Console.WriteLine($"You've made another step with your eternal goal and earned {pointsEarned} points! Your current score is {_player.GetScore()}.");
                Console.WriteLine("Keep it up!");
                break;
            case "ChecklistGoal":
                if (_goals[goalIndex].IsComplete())
                {
                    Console.WriteLine($"You've finally completed your checklist goal and earned {pointsEarned} points! Your current score is {_player.GetScore()}.");
                }
                else
                {
                    Console.WriteLine($"You've made another step with your checklist goal and earned {pointsEarned} points! Your current score is {_player.GetScore()}.");
                    Console.WriteLine("Keep it up!");
                }
                break;
            case "NegativeGoal":
                Console.WriteLine($"You've recorded a negative goal and lost {pointsEarned * -1} points. Your current score is {_player.GetScore()}.");
                Console.WriteLine("Keep trying you can do it!");
                break;
            case "AlternatingGoal":
                Console.WriteLine($"You've completed the alternating goal swapping it with it's counterpart and earning {pointsEarned} points! Your current score is {_player.GetScore()}.");
                break;
            default:
                Console.WriteLine($"You've recorded another goal and earned {pointsEarned} points! Your current score is {_player.GetScore()}.");
                break;
        }

    }

    private void SaveGoals()
    {
        Console.Write("Enter the file name to save goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_player.GetScore());
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter the file name to load goals: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                _player = new Player(int.Parse(reader.ReadLine()));
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split("::");
                    switch (parts[0])
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                            break;
                        case "NegativeGoal":
                            _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "AlternatingGoal":
                            _goals.Add(new AlternatingGoal(parts[1], parts[2], int.Parse(parts[3]), parts[4], parts[5], int.Parse(parts[6])));
                            break;
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}