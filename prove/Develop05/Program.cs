using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            // Load goals from file (if exists)
            goalManager.LoadGoals();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest");
                Console.WriteLine("1. Display Goals");
                Console.WriteLine("2. Create New Goal");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Display Score");
                Console.WriteLine("5. Save and Exit");
                Console.WriteLine("6. Exit Without Saving");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        goalManager.DisplayGoals();
                        break;
                    case "2":
                        goalManager.CreateGoal();
                        break;
                    case "3":
                        goalManager.RecordEvent();
                        break;
                    case "4":
                        Console.WriteLine($"Your current score: {goalManager.Score}");
                        Console.ReadKey();
                        break;
                    case "5":
                        goalManager.SaveGoals();
                        return;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }

    public class GoalManager
    {
        public int Score { get; private set; }
        private List<Goal> goals;

        public GoalManager()
        {
            goals = new List<Goal>();
            Score = 0;
        }

        public void CreateGoal()
        {
            Console.WriteLine("Select the type of goal to create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateSimpleGoal();
                    break;
                case "2":
                    CreateEternalGoal();
                    break;
                case "3":
                    CreateChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void CreateSimpleGoal()
        {
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for completing this goal: ");
            int points = int.Parse(Console.ReadLine());

            SimpleGoal goal = new SimpleGoal(description, points);
            goals.Add(goal);
        }

        private void CreateEternalGoal()
        {
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for each completion: ");
            int points = int.Parse(Console.ReadLine());

            EternalGoal goal = new EternalGoal(description, points);
            goals.Add(goal);
        }

        private void CreateChecklistGoal()
        {
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for each completion: ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("Enter number of times to complete: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points for completing the checklist: ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(description, points, target, bonus);
            goals.Add(goal);
        }

        public void RecordEvent()
        {
            DisplayGoals();

            Console.Write("Select a goal to record an event: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                int pointsEarned = goals[goalIndex].RecordEvent();
                Score += pointsEarned;
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void DisplayGoals()
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
            }
            Console.ReadKey();
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(Score);
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.ToDataString());
                }
            }
        }

        public void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    Score = int.Parse(reader.ReadLine());

                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split(';');
                        switch (data[0])
                        {
                            case "SimpleGoal":
                                goals.Add(new SimpleGoal(data[1], int.Parse(data[2]), bool.Parse(data[3])));
                                break;
                            case "EternalGoal":
                                goals.Add(new EternalGoal(data[1], int.Parse(data[2]), int.Parse(data[3])));
                                break;
                            case "ChecklistGoal":
                                goals.Add(new ChecklistGoal(data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                                break;
                        }
                    }
                }
            }
        }
    }

    public abstract class Goal
    {
        public string Description { get; private set; }
        public int Points { get; private set; }

        public Goal(string description, int points)
        {
            Description = description;
            Points = points;
        }

        public abstract int RecordEvent();
        public abstract string DisplayStatus();
        public abstract string ToDataString();
    }

    public class SimpleGoal : Goal
    {
        public bool IsCompleted { get; private set; }

        public SimpleGoal(string description, int points, bool isCompleted = false)
            : base(description, points)
        {
            IsCompleted = isCompleted;
        }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                return Points;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return $"{Description} - {(IsCompleted ? "[X]" : "[ ]")} - {Points} points";
        }

        public override string ToDataString()
        {
            return $"SimpleGoal;{Description};{Points};{IsCompleted}";
        }
    }

    public class EternalGoal : Goal
    {
        public int TimesCompleted { get; private set; }

        public EternalGoal(string description, int points, int timesCompleted = 0)
            : base(description, points)
        {
            TimesCompleted = timesCompleted;
        }

        public override int RecordEvent()
        {
            TimesCompleted++;
            return Points;
        }

        public override string DisplayStatus()
        {
            return $"{Description} - Completed {TimesCompleted} times - {Points} points per completion";
        }

        public override string ToDataString()
        {
            return $"EternalGoal;{Description};{Points};{TimesCompleted}";
        }
    }

    public class ChecklistGoal : Goal
    {
        public int Target { get; private set; }
        public int Bonus { get; private set; }
        public int TimesCompleted { get; private set; }

        public ChecklistGoal(string description, int points, int target, int bonus, int timesCompleted = 0)
            : base(description, points)
        {
            Target = target;
            Bonus = bonus;
            TimesCompleted = timesCompleted;
        }

        public override int RecordEvent()
        {
            if (TimesCompleted < Target)
            {
                TimesCompleted++;
                if (TimesCompleted == Target)
                {
                    return Points + Bonus;
                }
                return Points;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            return $"{Description} - Completed {TimesCompleted}/{Target} times - {Points} points per completion, {Bonus} bonus points";
        }

        public override string ToDataString()
        {
            return $"ChecklistGoal;{Description};{Points};{Target};{Bonus};{TimesCompleted}";
        }
    }
}