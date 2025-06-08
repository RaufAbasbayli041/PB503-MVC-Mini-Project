namespace CAConferenceManagement.Entity
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
