public class Activity
{
    // Base Attributes set as protected so that the other activities can set them.
    // In practice this should only be during construction save for the duration which should only be read as needed.
    protected string _name;
    protected string _description;
    protected int _duration;
    private int _defaultDuration;

    // Base Constructor
    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is the generalized Activity. If you are seeing this there's been an error.";
        _duration = 30;
        _defaultDuration = 30;
    }

    // Base Methods
    public void DisplayStartMsg()
    {
        Console.WriteLine($"---\nActivity: {_name}\n Description: {_description}\n Default Duration: {_defaultDuration} seconds\n---\n");
        Console.WriteLine("Change duration (y/n)?");
        Console.Write("> ");
        string choice = Console.ReadLine();

        while (choice != "y" && choice != "n")
        {
            Console.WriteLine("Please enter 'y' or 'n'");
            Console.Write("> ");
            choice = Console.ReadLine();
        }

        if (choice == "y")
        {
            Console.WriteLine("Enter new duration in seconds.");
            Console.Write("> ");
            choice = Console.ReadLine();

            while (true)
            {
                if (int.TryParse(choice, out int newDuration))
                {
                    _duration = newDuration;
                    Console.WriteLine("New duration has been chosen.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    choice = Console.ReadLine();
                }
            }
        }
        else 
        {
            _duration = _defaultDuration;
        }

        ShowSpinner(5); // Pause for 5 seconds with a spinner animation
        Console.WriteLine($"Activity: {_name} will start now for a duration of {_duration} seconds.");
        ShowCountdown(5);

    }

    public void DisplayEndMsg()
    {
        Console.WriteLine("\nGood Job!");
        ShowCountdown(5);
        Console.WriteLine($"\nYou completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinnerChars = { '|', '/', '-', '\\' };
        int spinnerIndex = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("\r" + spinnerChars[spinnerIndex]);
            spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
            Thread.Sleep(100);
        }

        Console.WriteLine();
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write("\r" + i); 
            Thread.Sleep(1000); 
        }

        Console.WriteLine();
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }
}