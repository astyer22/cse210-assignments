using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenertor = new Random();
        int magicNumber = randomGenertor.Next(1, 101);

        while (true)
        {
            Console.Write("Guess the magic number: ");
            string guess = Console.ReadLine();

            if (magicNumber == int.Parse(guess))
            {
                Console.WriteLine("Good job! You guessed the magic number!");
                break;
            }
            else if (magicNumber > int.Parse(guess))
            {
                Console.WriteLine("Too low! Try again!");
            }
            else if (magicNumber < int.Parse(guess))
            {
                Console.WriteLine("Too high! Try again!");
            }
        }
    }
}

      