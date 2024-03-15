using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> files = new List<string>();
        Random ran = new Random();

        // Both files found from here: https://scriptures.nephi.org/
        files.Add("kjv-scriptures-json.txt");
        files.Add("lds-scriptures-json.txt");

        int fileChoice = ran.Next(files.Count);

        // The scriptures are loaded from the chosen file.
        ScriptureLoader loader = new ScriptureLoader(files[fileChoice]);

        // A random selection is chosen from the loaded json
        // From the inital verse up to 5 are chosen with checks to make sure they're in the same book
        loader.ChoseScriptures();

        Scripture scripture = new Scripture(loader.GetReference(), loader.GetText());

        while (true)
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string choice = Console.ReadLine();

            if (choice != "quit")
            {
                if (scripture.isCompletelyHidden())
                {
                    break;   
                }

                int numberToHide = ran.Next(4);

                scripture.HideRandomWords(numberToHide);
                Console.Clear();
            }
            else
            {
                break;
            }
        }
    }
}