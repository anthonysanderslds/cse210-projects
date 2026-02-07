public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private List<int> _usedUpPrompts = new List<int>();
    private List<string> _userResponses = new List<string>();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        
    }

    public void Run()
    {
        int ready = 10;
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine();
        Console.Write("Get ready to begin: ");

        ShowCountdown(ready);

        Console.WriteLine();
        _count = GetListFromUser().Count;

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_usedUpPrompts.Count == _prompts.Count){
            _usedUpPrompts.Clear();
        }

        int randomIndex = _random.Next(_prompts.Count);

        while (_usedUpPrompts.Contains(randomIndex))
        {
            randomIndex = _random.Next(_prompts.Count);
        }
        _usedUpPrompts.Add(randomIndex);
        return _prompts[randomIndex];
    }

    public List<string> GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            _userResponses.Add(Console.ReadLine());
        }

        return _userResponses;
    }
}