public class Entry
{
    public string PromptText {get; set;}
    public string ResponseText {get; set;}
    public string DateText {get; set;}

// Needed this empty Entry() method to fix the JSON deserialization when using option 4
public Entry()
    {
    }

    public Entry(string prompt, string response, string date)
    {
        PromptText = prompt;
        ResponseText = response;
        DateText = date;
    }

    public string Display()
    {
        return $@"Date: {DateText} - Prompt: {PromptText}
        {ResponseText}
        ";
    }
}