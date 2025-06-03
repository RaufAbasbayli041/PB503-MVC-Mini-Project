namespace CAConferenceManagement.Entity
{
    public class Organizer : Person
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
