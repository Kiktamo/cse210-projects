using System.Collections.Generic;
using System.IO;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        LoadPrompts();
    }

    public void Run()
    {
        DisplayStartMsg();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowCountdown(5); // Give the user 5 seconds to think

        Console.WriteLine("Start listing items:");
        List<string> items = GetListFromUser();

        Console.WriteLine($"You listed {items.Count} items.");

        ShowCountdown(5);

        DisplayEndMsg();
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
            return "What are some of your favorite things in life?";

        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        // Timer starts now since this is the activity part of the activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        string input;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            input = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(input))
            {
                items.Add(input);
            }

        }

        return items;
    }

    private void LoadPrompts()
    {
        string filePath = "Listing_Prompts.txt";
        if (File.Exists(filePath))
        {
            _prompts.AddRange(File.ReadAllLines(filePath));
        }
        else
        {
            _prompts.Add("Who are people that you appreciate?");
            _prompts.Add("What are personal strengths of yours?");
            _prompts.Add("Who are people that you have helped this week?");
            _prompts.Add("When have you felt the Holy Ghost this month?");
            _prompts.Add("Who are some of your personal heroes?");
        }
    }
}