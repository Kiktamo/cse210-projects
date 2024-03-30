using System;

class Program
{
    static void Main(string[] args)
    {
        // As additions the response for each recording varies based on the goal type.
        // Negative Goals have been added decreasing points when recorded.
        // Alternating goals have also been added switching which goal is being completed with each recording.
        // A player class has also been added that keeps track of score and provides a rank/level
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}