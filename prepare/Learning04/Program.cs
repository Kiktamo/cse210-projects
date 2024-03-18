using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Alex Mercer", "Geography");
        Console.WriteLine("Assignment Test");
        Console.WriteLine(a1.GetSummary() + "\n");

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Samuel Jacobs", "Fractions", "7.3", "8-19");
        Console.WriteLine("MathAssignment Test");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList() + "\n");

        WritingAssignment a3 = new WritingAssignment("Jenna Grace", "European History", "Rise of the Industrial Revolution");
        Console.WriteLine("WritingAssignment Test");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation() + "\n");
    }
}