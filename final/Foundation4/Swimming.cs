namespace Foundation4
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(int minutes, string date, int laps) : base(minutes, date)
        {
            _laps = laps;
        }

        public override double Distance() =>Math.Round(_laps * 50/1000 * 0.621371);
        public void SetLaps(int laps) => _laps = laps;

        public override int Speed() => Math.Round(_laps / GetLengthInMinutes());

        public override int Pace() => Math.Round(GetLengthInMinutes() / _laps);

        public override string GetSummary()
        {
            return $"{GetDate()} {GetActivity()} ({GetLengthInMinutes()} min) - Distance: {Distance()} miles, Speed: {Speed()} mph, Pace: {Pace()} min per mile.";
        }
    }
}