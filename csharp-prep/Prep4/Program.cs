using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> Numbers = new List<int>();

        Console.WriteLine("Enter a number, if you want to stop enter 0: ");

        while (true)
        {
            Console.Write("Enter a number:" + " ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number != 0)
            {
                Numbers.Add(number);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"The numbers you entered are: {string.Join(", ", Numbers)}");
        Console.WriteLine($"The sum of the numbers is: {Numbers.Sum()}");
        Console.WriteLine($"The maximum number is: {Numbers.Max()}");
        Console.WriteLine($"The average of the numbers is: {Numbers.Average()}");
    }
}
