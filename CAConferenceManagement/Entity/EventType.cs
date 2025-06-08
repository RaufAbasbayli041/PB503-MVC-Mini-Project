namespace CAConferenceManagement.Entity
{
    public class EventType : BaseEntity
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
}
