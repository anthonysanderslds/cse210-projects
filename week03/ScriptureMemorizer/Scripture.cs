using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

public class Scripture
{
        private Reference _reference;
        private List<Word> _words;

        //constructor to create word objects
        public Scripture(Reference reference, string text)
        {
                _reference = reference;
                _words = new List<Word>();

                string[] wordList = text.Split(" ");

                foreach(string word in wordList)
                {
                        _words.Add(new Word(word));
                }
        }

        //hide random words method
        public void HideRandomWords(int numberToHide)
        {
                List<Word> unhiddenWords = new List<Word>();

                foreach(Word word in _words)
                {
                        if (!word.IsHidden())
                        {
                                unhiddenWords.Add(word);
                        }
                }

                int wordsToHide = Math.Min(numberToHide, unhiddenWords.Count);
                Random random = new Random();
                
                for(int i = 0; i < wordsToHide; i++)
                {
                        int randomIndex = random.Next(unhiddenWords.Count);
                        unhiddenWords[randomIndex].Hide();
                        unhiddenWords.RemoveAt(randomIndex);
                }

        }

        //display text from the reference object
        public string GetDisplayText()
        {
                string text = _reference.GetDisplayText();

                string scriptureText = "";

                foreach(Word word in _words)
                {
                       scriptureText += word.GetDisplayText() + " ";
                }

                return $"{text} {scriptureText}";
        }

        //check if the text is completely hidden
        public bool IsCompletelyHidden()
        {
                foreach(Word word in _words)
                {

                        if (!word.IsHidden())
                        {
                                return false;
                        }
                }
                return true;
        }
}