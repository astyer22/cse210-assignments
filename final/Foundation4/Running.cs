// Derived Running class
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / distance;
    }
}