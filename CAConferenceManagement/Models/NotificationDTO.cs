namespace CAConferenceManagement.Models
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int OrganizerId { get; set; }
        public int EventId { get; set; }
        public bool IsRead { get; set; }
     
    }
}
