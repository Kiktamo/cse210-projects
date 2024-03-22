using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        // A majority of my main loop is in the menu class.
        // Things should work generally as I understood the specifications and similar to the video
        // Prompts and questions are loaded from a file but have internal fallbacks for the default questions given
        // Some additional prompts and questions have been added in the associated text files.
        // As an addition the menu keeps track of statistics with the number of times an activity has been done and the total seconds

        menu.Run();
    }
}