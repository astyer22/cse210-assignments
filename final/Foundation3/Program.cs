using System;
using Foundation3;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "62701");
        Address address2 = new Address("456 Elm St", "Springfield", "IL", "62702");
        Address address3 = new Address("789 Oak St", "Springfield", "IL", "62703");

        Lecture lecture1 = new Lecture("Intro to Sewing", "Learn the basics of Sewing", "10/1/2021", "10:00 AM", address1, "John Doe", 100);
        Reception reception1 = new Reception("First Friday", "Student Meet and Greet", "10/1/2021", "6:00 PM", address2, "Rober.Ty.Littles@gmail.com");
        Outdoor outdoor1 = new Outdoor("Picnic in the Park", "Bring your own lunch", "10/2/2021", "12:00 PM", address3, "Sunny");

        Console.WriteLine("Leture")
        Console.WriteLine(lecture1.GetFullDetails());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(lecture1.GetShortDescription());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(lecture1.GetStandardDetails());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine("\n"); // This will print a new line

        Console.WriteLine(reception1.GetFullDetails());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(reception1.GetShortDescription());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(reception1.GetStandardDetails());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine("\n"); // This will print a new line

        Console.WriteLine(outdoor1.GetFullDetails());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(outdoor1.GetShortDescription());
        Console.WriteLine("\n"); // This will print a new line
        Console.WriteLine(outdoor1.GetStandardDetails());


    }
}