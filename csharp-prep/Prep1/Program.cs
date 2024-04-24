using System;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?");
        string fname = Console.ReadLine();

        Console.Write("What is your last name?");
        string lname = Console.ReadLine();

        Console.Write($"Your name is {fname}, {fname} {lname}");
    }
}