using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string grade = Console.ReadLine();

        if (int.Parse(grade) >= 90)
        {
            Console.WriteLine("You get an A");
        }
        else if (int.Parse(grade) >= 80 && int.Parse(grade) < 90)
        {
            Console.WriteLine("You get a B");
        }
        else if (int.Parse(grade) >= 70 && int.Parse(grade) < 80)
        {
            Console.WriteLine("You get a C");
        }
        else if (int.Parse(grade) >= 60 && int.Parse(grade) < 70)
        {
            Console.WriteLine("You get a D");
    
        }
        else
        {
            Console.WriteLine("You get an F");
        }  

        if (int.Parse(grade) < 70)
        {
            Console.WriteLine("Bummer, you did not pass the class. You will need to retake the class.");
        }

        else 
        {
            Console.WriteLine("Congratulations, you passed!");
        }
    }
}