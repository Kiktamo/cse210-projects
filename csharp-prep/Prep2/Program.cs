using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else 
        {
            sign = "-";
        }

        if (grade <= 96 && grade >= 60) 
        {
            Console.WriteLine($"Your grade is {sign}{letter}");
        }
        else
        {
            Console.WriteLine($"Your grade is {letter}");
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Congratulations on Passing!");
        }
        else
        {
            Console.WriteLine($"Try again next time.");
        }
    }
}