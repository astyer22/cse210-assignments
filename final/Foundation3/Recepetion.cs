namespace Foundation3
{
    public class Receptions: Event
    {
        private string _rsvpEmail;

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
            {
                _rsvpEmail = rsvpEmail;
            }
        
        public string GetRsvpEmail() => _rsvpEmail;
        public void SetRsvpEmail(string email) => _rsvpEmail = email;

        public override string GetStandardDetails()
        {
            return $"{base.GetStandardDetails()}";
        }

        public string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {_rsvpEmail}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Reception\nTitle: {GetEventTitle()}\nDate: {GetEventDate()}";
        }
    }
}