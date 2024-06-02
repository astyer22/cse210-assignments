namespace Foundation4
{
    public class StaionaryBicycles : Activity
    {
        private double _speed;

        public StaionaryBicycles(int minutes, string date, int speed) : base(minutes, date)
        {
            _speed = speed;
        }

        public override double Speed() => _speed;

        public override double Distance() => (_speed * GetLengthInMinutes()) / 60;
        public override string GetSummary()
        {
            return $"{GetDate()} {GetActivity()} ({GetLengthInMinutes()} min) - Distance: {Distance()} miles, Speed: {Speed()} mph, Pace: {Pace()} min per mile.";
        }
    }
}