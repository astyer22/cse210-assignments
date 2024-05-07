using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void PrintJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {_endYear}");
    }
}

public class Resume
{
    public string _name;
    public Job job1;
    public Job job2;
    public Job job3;

    public void PrintResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Job 1:");
        job1.PrintJobDetails();
        Console.WriteLine("Job 2:");
        job2.PrintJobDetails();
        Console.WriteLine("Job 3:");
        job3.PrintJobDetails();
    }
}

public class Program
{
    public static void Main()
    {
        Resume resume = new Resume();
        resume._name = "Eliza Crane";

        resume.job1 = new Job();
        resume.job1._company = "ABC Family";
        resume.job1._jobTitle = "Software Engineer";
        resume.job1._startYear = 2018;
        resume.job1._endYear = 2023;

        resume.job2 = new Job();
        resume.job2._company = "Verizon";
        resume.job2._jobTitle = "Software Engineer";
        resume.job2._startYear = 2015;
        resume.job2._endYear = 2018;

        resume.job3 = new Job();
        resume.job3._company = "T-Mobile";
        resume.job3._jobTitle = "Software Engineer";
        resume.job3._startYear = 2013;
        resume.job3._endYear = 2015;

        resume.PrintResume();
    }
}
