namespace CAConferenceManagement.Entity
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; }
        public DateTime SentAy { get; set; } = DateTime.UtcNow;
        public int EventId { get; set; }
        public Event Event { get; set; }
      
    }
}
