using System;

class Program
{
    static void Main(string[] args)
    {
        int number = -1;
        int sum = 0;
        double average = 0;
        int largest = 0;
        List<int> numberList = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {
            Console.Write("Enter Number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numberList.Add(number);
            }
        }
        
        foreach (int item in numberList)
        {
            sum += item;
            if (item > largest)
            {
                largest = item;
            }
        }

        average = ((float)sum) / numberList.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}