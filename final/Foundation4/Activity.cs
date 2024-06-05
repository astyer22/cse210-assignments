// Base Activity class
public abstract class Activity
{
    private DateTime date;
    private int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public DateTime Date { get => date; }
    public int Duration { get => duration; }

    // Virtual methods for derived classes to override
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // GetSummary method to produce summary information
    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {this.GetType().Name} ({Duration} min) - " +
               $"Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}