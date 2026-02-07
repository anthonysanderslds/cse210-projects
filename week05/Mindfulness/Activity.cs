using System.Runtime.InteropServices.Marshalling;

public class Activity
{
    //initialize variables
    protected string _name;
    protected string _description;
    protected int _duration;

    //Activity Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    //DisplayStartingMessage method
    public void DisplayStartingMessage()
    {
        _duration = 0;
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    //DisplayEndingMessage method
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(5);
        Console.Clear();
    }

    //Animation for the show spinner method
    public void ShowSpinner(int seconds)
    {
        Console.CursorVisible = false; //hide the cursor so it's not blinking weird

        //calculate future timestamp for the seconds entered
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(seconds);

        //create the animation list and initialize index variable
        List<string> spinner = new List<string>{"-", "--", "---", "----", " ---", "  --", "   -"};
        int spinnerIndex = 0;

        //run the animation for the seconds entered
        while (DateTime.Now < futureTime)
        {
            string currentSpinner = spinner[spinnerIndex % spinner.Count];
            Console.Write(currentSpinner);
            Thread.Sleep(250);

            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            spinnerIndex ++;
        }

        Console.CursorVisible = true; //show the cursor again after animation has concluded
    }

    //countdown method
    public void ShowCountdown(int seconds)
    {
        Console.CursorVisible = false; //hide the cursor so it's not blinking weird

        //while loop to countdown
        while (seconds != 0)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);

            //handle countdown where the seconds are more than 1 digit
            int digitCount = seconds.ToString().Length;
            for (int i = 0; i < digitCount; i++)
            {
                Console.Write("\b \b");
            }
            seconds--;
        }
        Console.CursorVisible = true; //show the cursor again after countdown is concluded
    }
}