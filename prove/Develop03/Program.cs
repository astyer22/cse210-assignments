using System;
using System.Collections.Generic;

class Scripture
{
    private List<Word> _words;
    private int _currentIndex;
    public void HideNextWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _words.Count);

        if (randomIndex < _words.Count)
        {
            _words[randomIndex].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                displayText += "____ ";
            }
            else
            {
                displayText += word.GetText() + " ";
            }
        }

        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public Scripture()
    {
        _words = new List<Word>();
        string scriptureText = "Mosiah 23: 21-22; 21)Nevertheless the Lord seeth fit to chasten his people; yea, he trieth their patience and their faith. 22)Nevertheless—whosoever putteth his trust in him the same shall be lifted up at the last day. Yea, and thus it was with this people.";
        string[] words = scriptureText.Split(' ');

        foreach (string word in words)
        {
            Word newWord = new Word();
            newWord.SetText(word);
            _words.Add(newWord);
        }

        _currentIndex = 0;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.ReadKey(); // Wait for user to hit enter
            scripture.HideNextWord();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
