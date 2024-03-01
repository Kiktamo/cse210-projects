using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
    List<int> numbers = new List<int>();
    
    Console.WriteLine("Enter a list of numbers, type 0 when finished.");
    
    int input;
    
    do 
    {
        Console.Write("Enter number: ");
        input = Convert.ToInt32(Console.ReadLine());
      
        if (input != 0) 
        {
            numbers.Add(input);  
        }
      
    } while (input != 0);
    
    int sum = 0;
    foreach (int num in numbers) 
    {
      sum += num;
    }
    
    float average = ((float)sum) / numbers.Count;
    
    int max = numbers.Max();
    
    int minPositive = numbers.Where(n => n > 0).Min();
    
    numbers.Sort();
    
    Console.WriteLine("\nThe sum is: " + sum);
    Console.WriteLine("The average is: " + average); 
    Console.WriteLine("The largest number is: " + max);
    Console.WriteLine("The smallest positive number is: " + minPositive);
    
    Console.WriteLine("\nThe sorted list is:");
    foreach (int num in numbers) 
    {
      Console.WriteLine(num);
    }
    }
}