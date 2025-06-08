using CAConferenceManagement.Helpers.Enum.InvitationStatus;

namespace CAConferenceManagement.Entity
{
    public class Invitation : BaseEntity
    {
        public InvitationStatus Status { get; set; }
        public int EventId { get; set; }    
        public Event Event { get; set; }
        public int UserId { get; set; }   
        public User User { get; set; }
        public Participation Participation { get; set; }
    }
}
