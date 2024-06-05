namespace Foundation3
{
public class Lecture: Event 
{
    
    private string _speakerName;
    private int _capacity;
    
    public Lecture(string title, string description, string date, string time, Address address, string speakerName, int capacity)
            : base(title, description, date, time, address)
        {
            _speakerName = speakerName;
            _capacity = capacity;
        }

        public string GetSpeakerName() => _speakerName;
        public void SetrSpeakerName(string name) => _speakerName = name;
        public int GetCapacity() => _capacity;
        public void SetCapacity(int capacity) => _capacity = capacity;

    public override string GetStandardDetails()
        {
            return $"{base.GetStandardDetails()}";
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Lecture\nTitle: {GetEventTitle()}\nDate: {GetEventDate()}";
        }
    
}
}