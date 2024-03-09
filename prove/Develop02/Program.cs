using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Other additions outside of the main program are that the PromptGen class automatically loads
        // its list from those in prompts.txt for easy addition.
        
        // Dates for entrys are stored as DateTime and only display in the short format
        // to allow sorting them before display and save, so that the journal sould always be in order.

        Journal journal = new Journal();
        bool loop = true;

        while (loop)
        {
            // Basic Program Loop.
            Console.WriteLine("\nPlease Select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            Console.Write("> ");


            string selection = Console.ReadLine();

            bool properChoice = int.TryParse(selection, out int choice);
            if (!properChoice){
                choice = 0;
            }

            // Ended up looking up Switch statements for C# on W3 Schools when deciding to do it this way.
            switch (choice)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    journal.Load();
                    break;
                case 4:
                    // As an improvement the journal is saved as a json.
                    journal.Save();
                    break;
                case 5:
                    // The journal sets _saved to false whenever a new entry is added, and sets it to true during saving or loading.
                    if (journal._saved)
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Journal hasn't been saved.");
                        Console.WriteLine("Save before exiting? (y/n)");
                        Console.Write("> ");

                        string choiceSave = Console.ReadLine();

                        while (true)
                        {
                            if (choiceSave.ToLower() == "y")
                            {
                                journal.Save();
                                loop = false;
                                break;
                            }
                            else if (choiceSave.ToLower() == "n")
                            {
                                loop = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please choose 'y' or 'no'");
                                Console.Write("> ");
                                choiceSave = Console.ReadLine();
                            }
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Please select one of the available choices.");
                    break;

            }
        }
    }
}