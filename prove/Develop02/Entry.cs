using System.Text.Json.Serialization;

public class Entry
{
    [JsonInclude]
    public string _prompt = "Free Write";
    [JsonInclude]
    public DateTime _date = DateTime.Now;
    [JsonInclude]
    public string _entry = "";

    public void Write()
    {
        _date = DateTime.Now;

        Console.WriteLine("Do you want to use a prompt? (y/n)");
        Console.Write("> ");

        string choice = Console.ReadLine();

        while (true)
        {
            if (choice.ToLower() == "y")
            {
                PromptGen promptGen = new PromptGen();

                _prompt = promptGen.GetRandomPrompt();

                break;
            }
            else if (choice.ToLower() == "n")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please choose 'y' or 'no'");
                Console.Write("> ");
                choice = Console.ReadLine();
            }
        }

        Console.WriteLine("Please write your entry.");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.Write("> ");

        _entry = Console.ReadLine();

    }

    public void Display()
    {
        Console.WriteLine($"\nPrompt: {_prompt}");
        Console.WriteLine($"Date: {_date.ToShortDateString()}");
        Console.WriteLine($"Entry: \n{_entry}");
    }

}