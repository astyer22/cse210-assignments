namespace Foundation4 // Replace YourNamespace with the actual namespace
{
    // Derived Swimming class
    public class Swimming : Activity
    {
        private readonly int laps;

        public Swimming(DateTime date, int duration, int laps)
            : base(date, duration)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * 50 / 1000 * 0.62; // Convert meters to miles
        }

        public override double GetSpeed()
        {
            return GetDistance() / Duration * 60;
        }

        public override double GetPace()
        {
            return Duration / GetDistance();
        }
      }
}
