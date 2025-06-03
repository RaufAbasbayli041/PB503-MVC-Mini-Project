namespace CAConferenceManagement.Entity
{
    public class Invitation : BaseEntity
    {
        public string Status { get; set; }
        public int EventId { get; set; }    
        public Event Event { get; set; }
        public int PersonId { get; set; }   
        public Person Person { get; set; }
        public Participation Participation { get; set; }
    }
}
