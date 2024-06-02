namespace Foundation4
{
    public class Running : Activity
    {
        private double _distance;

        public Running(int minutes, string date, int distance) : base(minutes, date)
        {
            _distance = distance;
        }

        public override int Distance() => _distance;
        public override string GetSummary()
        {
            return $"{GetDate()} {GetActivity()} ({GetLengthInMinutes()} min) - Distance: {Distance()} miles, Speed: {Speed()} mph, Pace: {Pace()} min per mile.";
        }

    }
}