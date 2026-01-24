using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class Word
{
    //set attributes
    private string _text;
    private bool _isHidden;

    //text constructor for words in scripture
    public Word(string text)
    {
        _text = text;
    }

    //method hide
    public void Hide()
    {
        _isHidden = true;
    }

    //method show
    public void Show()
    {
        _isHidden = false;
    }

    //check if is hidden is true
    public bool IsHidden()
    {
        if (_isHidden)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //convert text to '_' if is hidden is true, else return text
    public string GetDisplayText()
    {
        if (IsHidden())
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}