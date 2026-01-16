public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>();

        _prompts.Add("What was one way in which you served someone today?");
        _prompts.Add("How would you describe your happiest moment today and why?");
        _prompts.Add("What was a challenge you overcame today?");
        _prompts.Add("Did you have any great conversations today? Summarize one either way!");
        _prompts.Add("What was something new that stood out to you from your scripture study today?");
    }

    public string GetRandomPrompts()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

}