using System;
using System.Collections.Generic;
using System.IO;

class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _prompts = new List<string> 
        {
            "What was the scariest thing that happened to you today?",
            "What was the last thing you said to both of your parents? Do you think you should reach out?",
            "Was there any moment today when you felt lonely? How did you cope with it?",
            "Write about something kind someone did for you, then write about something kind you did for someone else.",
            "Reflect on a recent mistake you made. How did you handle it, and what did you learn from the experience?",
            "Describe a challenge you faced today. How did you overcome it, or what steps are you taking to address it?",
            "Think about a recent achievement or success. What contributed to your success, and how do you plan to build on it?",
            "Consider a goal you've been working towards. What progress have you made, and what steps do you still need to take to reach it?",
            "Reflect on a recent conversation that made you think deeply or changed your perspective. What was discussed, and how did it impact you?",
            "Describe a moment of joy or happiness you experienced today. What caused it, and how did it make you feel?",
            "Think about a decision you made today. How did you come to that decision, and do you feel confident about it?",
            "Consider a skill or talent you'd like to develop. What steps are you taking to improve in that area?",
            "Reflect on a recent interaction with a friend or family member. How did it make you feel, and what did you take away from it?",
            "Describe a recent experience that challenged your beliefs or assumptions. How did you respond, and did it lead to any personal growth?",
            "Think about a goal or dream you've had for a long time. What progress have you made towards achieving it, and what obstacles have you encountered?",
            "Reflect on a recent disappointment or setback. How did you cope with it, and what did you learn from the experience?",
            "Consider a recent act of kindness you witnessed. How did it make you feel, and did it inspire you to pay it forward?",
            "Describe a recent moment of self-discovery or personal insight. What led to this realization, and how has it influenced your thoughts or actions?"
        };
        _random = new Random();
    }
    
    public string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }
}

class Entry 
{
    public string _entryDate;
    public string _promptText;
    public string _entryText; 
   
    public void DisplayE()
    {
         Console.WriteLine($"Date: {_entryDate}");
         Console.WriteLine($"Prompt: {_promptText}");
         Console.Write($"Your Entry: {_entryText}");
         _entryText = Console.ReadLine();
         Console.WriteLine();
    }
}

class Journal
{
     public List<Entry> _entries;

     public Journal()
     {
         _entries = new List<Entry>();
     }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            _entries.Clear(); // Clear existing entries before loading from file
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] entryData = line.Split('|');
                    if (entryData.Length == 3)
                    {
                        Entry entry = new Entry();
                        entry._entryDate = entryData[0];
                        entry._promptText = entryData[1];
                        entry._entryText = entryData[2];
                        _entries.Add(entry);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {
                sw.WriteLine($"{entry._entryDate}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

     public void DisplayAllEntries()
     {
         foreach (Entry entry in _entries)
         {
            entry.DisplayE();
         }
     }
}

class Program
{
   static void Main()
{
    Journal journal = new Journal();
    PromptGenerator promptGenerator = new PromptGenerator();

    while (true)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Entry newEntry = new Entry();
                newEntry._entryDate = DateTime.Now.ToString("MM/dd/yyyy");
                newEntry._promptText = promptGenerator.GetRandomPrompt();
                newEntry.DisplayE();
                journal.AddEntry(newEntry);
                break;
            case "2":
                journal.DisplayAllEntries();
                break;
            case "3":
                Console.Write("Enter file name to save: ");
                string saveFileName = Console.ReadLine();
                journal.SaveToFile(saveFileName);
                break;
            case "4":
                Console.Write("Enter file name to load: ");
                string loadFileName = Console.ReadLine();
                journal.LoadFromFile(loadFileName);
                if (journal._entries.Count > 0)
                {
                    Console.WriteLine("Journal loaded successfully.");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                break;
        }
    }
}
}
