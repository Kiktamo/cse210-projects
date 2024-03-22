using System.Collections.Generic;
using System.IO;

public class Menu
{
    private BreathingActivity _breathing;
    private ReflectionActivity _reflect;
    private ListingActivity _listing;
    private Dictionary<string, int> _statistics;

    public Menu()
    {
        _breathing = new BreathingActivity();
        _reflect = new ReflectionActivity();
        _listing = new ListingActivity();

        _statistics = new Dictionary<string, int>();
        LoadStatistics();
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();

            DisplayActivities();
            Console.WriteLine("4. Display Statistics");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _breathing.Run();
                    UpdateStatistics(_breathing.GetName(), _breathing.GetDuration());
                    break;
                case "2":
                    _listing.Run();
                    UpdateStatistics(_listing.GetName(), _listing.GetDuration());
                    break;
                case "3":
                    _reflect.Run();
                    UpdateStatistics(_reflect.GetName(), _reflect.GetDuration());
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    SaveStatistics();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void DisplayActivities()
    {
        Console.WriteLine($"1. {_breathing.GetName()}");
        Console.WriteLine($"2. {_listing.GetName()}");
        Console.WriteLine($"3. {_reflect.GetName()}");

    }

    private void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("Activity Statistics:");
        Console.WriteLine();

        foreach (var stat in _statistics)
        {
            if (!stat.Key.Contains("Time"))
            {
                Console.WriteLine($"{stat.Key}: {stat.Value} times");
            }
            else
            {
                Console.WriteLine($"{stat.Key}: {stat.Value} seconds");
            }
        }

        Console.WriteLine();
    }

    private void LoadStatistics()
    {
        string filePath = "statistics.txt";
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string activityName = parts[0].Trim();
                    int count = int.Parse(parts[1].Trim());
                    _statistics[activityName] = count;
                }
            }
        }
    }

    private void SaveStatistics()
    {
        string filePath = "statistics.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var stat in _statistics)
            {
                writer.WriteLine($"{stat.Key}: {stat.Value}");
            }
        }
    }

    private void UpdateStatistics(string activityName, int duration)
    {
        if (_statistics.ContainsKey(activityName))
        {
            _statistics[activityName]++;
            _statistics[activityName + " Total Time"] += duration;
        }
        else
        {
            _statistics[activityName] = 1;
            _statistics[activityName + " Total Time"] = duration;
        }
    }
}