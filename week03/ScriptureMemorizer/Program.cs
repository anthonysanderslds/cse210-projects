//Exceeding Requirements: I added JSON logic for the user to input their own
//scripture which would then request the text of that scripture from an API source and return the text
//I also cleaned up the console a little bit to add space so the program was a bit more readable.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine();
        Console.Write("What scripture would you like to memorize? ");
        string userInput = Console.ReadLine();


        string[] parts = userInput.Split(":");
        string bookAndChapter = parts[0];
        string versesPart = parts[1];

        int index = bookAndChapter.LastIndexOf(" ");
        string book = bookAndChapter.Substring(0, index);
        int chapter = int.Parse(bookAndChapter.Substring(index + 1));
        int startVerse = 0;
        int endVerse = 0;
        int verse = 0;


        if (versesPart.Contains("-"))
        {
            string[] verseArray = versesPart.Split("-");
            startVerse = int.Parse(verseArray[0]);
            endVerse = int.Parse(verseArray[1]);
        }
        else
        {
            verse = int.Parse(versesPart);
        }

        string encodedReference = Uri.EscapeDataString(userInput);
        string url = $"https://api.nephi.org/scriptures/?q={encodedReference}";

        Console.WriteLine($"Requesting URL: {url}");

        using HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(response);
        JsonElement root = doc.RootElement;
        JsonElement scripturesArray = root.GetProperty("scriptures");

        string scriptureText = "";

        foreach (JsonElement scriptureElement in scripturesArray.EnumerateArray())
        {
            string verseText = scriptureElement.GetProperty("text").GetString();
            scriptureText += verseText + "";
        }

        scriptureText = scriptureText.Trim();

        Reference reference;

        if (versesPart.Contains("-"))
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            reference = new Reference(book, chapter, verse);
        }

        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Please enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine($"Excellent work memorizing {userInput}!");
        Console.WriteLine();
    }
}