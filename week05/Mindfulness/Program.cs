//I showed creativity by adding logic to ensure that prompts/questions were not used 
//more than once until all have been used. I also added additional prompts to give 
//more context to the user for each activity.
using System;

class Program
{
    static void Main(string[] args)
    {
        //Display welcome message
        Console.Clear();
        Console.WriteLine("Hello! Welcome to the Mindfulness Program. We're glad you're here!");
        Console.WriteLine();

        //Display Options (loop)
        string userInput = "";

        while (userInput != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu (1-4): ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                Console.Clear();
            }
            else if (userInput == "2")
            {
                ReflectingActivity reflection = new ReflectingActivity();
                reflection.Run();
            }
            else if (userInput == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (userInput == "4")
            {
                Console.WriteLine();
                Console.WriteLine("Hope to see you again soon!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again, entering a number between 1 and 4.");
                Console.WriteLine();
            }
        }
    }
}