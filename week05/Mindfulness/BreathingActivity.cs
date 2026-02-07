public class BreathingActivity : Activity
{
    //BreathingActivity constructor calling the base class (Activity)
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        
    }

    //Run method for Breathing
    public void Run()
    {
        DisplayStartingMessage(); //call starting message
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(3);
        Console.WriteLine();

        //calculate duration for run time
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);

        //while loop for breathing exercise
        while (currentTime < futureTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountdown(6);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        DisplayEndingMessage(); //call end message
    }
}