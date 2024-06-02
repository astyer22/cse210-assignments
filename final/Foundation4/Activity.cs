namespace Foundation4
{
    public class Activity
    {
        private int _lengthInMinutes;
        private string _date;
        private string _activityType;

        public Activity(int minutes, string date, string activity)
        {
            _lengthInMinutes = minutes;
            _date = date;
            _activityType = activity
        }

        public string GetDate() => _date;
        public void SetDate(string date) => _date = date;
        public int GetLengthInMinutes() => _lengthInMinutes;
        public void SetLengthInMinutes(int minutes) => _lengthInMinutes = minutes;
        public string GetActivity() => _activityType;
        public void SetActivity(string activity) => _activityType = activity;

        public virtual int Distance() => 0.0;
       public virtual double Speed() => Math.Round((Distance() / _lengthInMinutes) * 60, 2);
        public virtual double Pace() => Math.Round((double)_lengthInMinutes / Distance(), 2); 

        public virtual GetSummary()
        {
             return $"{_date} {_activityType} ({_lengthInMinutes} min) - Distance: {Distance()} miles, Speed: {Speed()} mph, Pace: {Pace()} min per mile.";
        }
    }
}