using System;

class Program
{
    static void Main(string[] args)
    {
        bool game_loop = true;

        while (game_loop)
        {
            Console.WriteLine("Guess a number between 1 and 100");

            Random randomGenerator = new Random();
            int magic_number = randomGenerator.Next(1, 100);

            int guess_number = 0;
            int guess_counter = 0;

            while (guess_number != magic_number)
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guess_number = int.Parse(guess);

                if (guess_number < magic_number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess_number > magic_number)
                {
                    Console.WriteLine("Lower");
                }
                guess_counter++;
            }

            Console.WriteLine("\nYou guessed it!");
            Console.WriteLine($"It took you {guess_counter} tries!");
            Console.Write("\nPlay again? (yes or no) ");

            string choice = Console.ReadLine();

            while (true)
            {
                if (choice == "yes")
                {
                    break;
                }
                else if (choice == "no")
                {
                    game_loop = false;
                    break;
                }
                else
                {
                    Console.Write("Please choose yes or no: ");
                    choice = Console.ReadLine();
                }
            }

        }
    }
}