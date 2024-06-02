namespace Foundation3
{
 public class Event
    {
        private string _eventTitle;
        private string _eventDescription;
        private string _eventDate;
        private string _eventTime;
        private Address _eventAddress;

        public Event(string title, string description, string date, string time, Address address)
        {
            _eventTitle = title;
            _eventDescription = description;
            _eventDate = date;
            _eventTime = time;
            _eventAddress = address;
        }

        public string GetEventTitle() => _eventTitle;
        public void SetEventTitle(string title) => _eventTitle = title;

        public string GetEventDescription() => _eventDescription;
        public void SetEventDescription(string description) => _eventDescription = description;

        public string GetEventDate() => _eventDate;
        public void SetEventDate(string date) => _eventDate = date;

        public string GetEventTime() => _eventTime;
        public void SetEventTime(string time) => _eventTime = time;

        public Address GetEventAddress() => _eventAddress;
        public void SetEventAddress(Address address) => _eventAddress = address;

        public virtual string GetStandardDetails()
        {
            return $"Title: {_eventTitle}\nDescription: {_eventDescription}\nDate: {_eventDate}\nTime: {_eventTime}\nAddress: {_eventAddress.GetFullAddress()}";
        }

        public virtual string GetFullDetails()
        {
            return GetStandardDetails();
        }

        public virtual string GetShortDescription()
        {
            return $"Event Type: {GetType().Name}\nTitle: {_eventTitle}\nDate: {_eventDate}";
        }
    }
}