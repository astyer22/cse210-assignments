using System;

class Assigments 
{
    protected string _studentName;
    protected string _topic;

    Assigments()
    {
        _studentName = "name";
        _topic = "topic";
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public void SetStudentName(string name)
    {
        _studentName = name;
    }

    public string GetSummary()
    {
        return "Student Name: " + _studentName + " Topic: " + _topic 
    }
}

class MathAssignments : Assignments
{
    private string _textbookSection;
    private string _problems;

    MathAssignments()
    {
        _textbookSection = "section";
        _problems = "problems";
    }

    public override string GetSummary()
    {
        // Call the base implementation of GetSummary
        string baseSummary = base.GetSummary();

        // Add additional information specific to MathAssignments
        string mathSummary = baseSummary + " Textbook Section: " + _textbookSection + " Problems: " + _problems;

        return mathSummary;
    }
}

class WritingAssignment : Assigments
{
    private string _title;

    WritingAssignment()
    {
        _title = "title";
    }

    string baseSummary = base.GetSummary();

    GetWritingInformation()
    {
        return baseSummary + " Title: " + _title;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Assigments assigment1 = new Assigments();
        assignment1.SetStudentName("John Doe");
        assignment1.SetTopic("History");
        Console.WriteLine($"{assignment1.GetSummary()}");

        MathAssignments assignment2 = new WritingAssignment();
        assignment2.SetStudentName("Jane Doe");
        assignment2.SetTopic("Algebra");
        assignment2.SetTextbookSection("Chapter 3");
        assignment2.SetProblems("3.1 to 3.5");
        Console.WriteLine($"{assignment2.GetSummary()}");
        Console.WriteLine($"{assignment2.GetMathAssignments()}");

        WritingAssignment assignment3 = new WritingAssignment();
        assignment3.SetStudentName("Jim Doe");
        assignment3.SetTopic("English");
        assignment3.SetTitle("The Great Gatsby");
        Console.WriteLine($"{assignment3.GetSummary()}");
        Console.WriteLine($"{assignment3.GetWritingInformation()}");

    }
}