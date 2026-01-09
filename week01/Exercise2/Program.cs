using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the grade value (example: 90): ");
        string value = Console.ReadLine();
        int number = int.Parse(value);
        string letter = "";

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        Console.WriteLine($"Your grade: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("You passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
    }
}