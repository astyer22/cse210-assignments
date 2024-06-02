namespace Foundation3
{ 
   public class Outdoor: Event

    {
        private string _weatherForcast;

        public Outdoor(string title, string description, string date, string time, Address address, string weatherForcast)
            : base(title, description, date, time, address)
        {
            _weatherForcast = weatherForcast;
        }

        public string GetWeatherForcast() => _weatherForcast;
        public void SetWeatherForcast(string weatherForcast) => _weatherForcast = weatherForcast;

        public string GetWeather()
        {
            return _weather;
        }
        public void SetWeather(string weather)
        {
            _weather = weather;
        }

        public override string GetStandardDetails()
        {
            return $"{base.GetStandardDetails()}";
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Outdoor\nWeather Forecast: {_weatherForecast}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Outdoor\nTitle: {GetEventTitle()}\nDate: {GetEventDate()}";
        }
    }
}