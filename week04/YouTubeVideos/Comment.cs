using System.Security.AccessControl;

public class Comment
{
    private string _commenter;
    private string _commentText;

    public Comment(string commenter, string text)
    {
        _commenter = commenter;
        _commentText = text;
    }

    public string GetComment()
    {
        return $"{_commenter}: {_commentText}";
    }
}