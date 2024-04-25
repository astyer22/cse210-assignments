using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage("Welcome to the Program!");
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number, name);
    }
    
    static void DisplayWelcomeMessage(string message)
    {
        Console.WriteLine(message);
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    static int SquareNumber(int number, string name)
    {
        Console.Write($"Hello, {name}!" + " ");
        Console.WriteLine($"The square of {number} is: {number * number}");
        return number * number;
    }
}
