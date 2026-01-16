// To exceed core requirements, I researched and included JSON components by adding the 'System.Text.Json' and 'System.IO' libraries
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal entry to a file");
            Console.WriteLine("4. Load a journal from a file");
            Console.WriteLine("5. Quit the program");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompts();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(prompt, response, date);
                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thank you! Have a nice day!");
            }
            else
            {
                Console.WriteLine("Invalid Choice. Please select a valid option (1-5).");
            }
        }
    }
}