public class ReflectingActivity : Activity
{
    //prompts list
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you did something truly selfless."
    };

    //questions list
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    //initialize remaining helpers for creativity points (preventing using same random prompts/questions)
    private Random _random = new Random();

    private List<int> _usedPrompts = new List<int>();

    private List<int> _usedQuestions = new List<int>();

    //Reflecting activity constructor calling base class (Activity)
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }

    //Run method for reflecting activity
    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        ShowSpinner(10); //get spinner animation going
        Console.WriteLine();
        DisplayQuestions();
        DisplayEndingMessage(); //call ending message
    }

    //method for random prompt
    public string GetRandomPrompt()
    {
        //check that prompt was not already used
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear(); //clear if all prompts have been used
        }

        int randomIndex = _random.Next(_prompts.Count); //get a random prompt index number

        //keep getting a new prompt if the one it randomized was already used
        while (_usedPrompts.Contains(randomIndex))
        {
            randomIndex = _random.Next(_prompts.Count);
        }
        _usedPrompts.Add(randomIndex); //add used prompt to used prompt list
        return _prompts[randomIndex]; //return qualifying prompt
    }

    //method for random prompt
    public string GetRandomQuestion()
    {
        //check if question was used
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear(); //clear the list if all questions have been used
        }

        int randomIndex = _random.Next(_questions.Count); //get a random questions index number

        //while loop to generate random index
        while (_usedQuestions.Contains(randomIndex))
        {
            randomIndex = _random.Next(_questions.Count);
        }
        _usedQuestions.Add(randomIndex); //add used questions to used questions list
        return _questions[randomIndex]; //return random question
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine($"Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} --- "); //get prompt from list
    }

    public void DisplayQuestions()
    {
        //calculate duration amount
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");
        Console.WriteLine();

        //while loop for random question asking through duration
        while (DateTime.Now < futureTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}"); //call random question method
            ShowSpinner(10); //call spinner animation
        }
    }
}