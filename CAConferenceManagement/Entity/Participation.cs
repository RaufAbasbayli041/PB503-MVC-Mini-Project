namespace CAConferenceManagement.Entity
{
    public class Participation : BaseEntity
    {
        public int SeatNumber { get; set; }
        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }
        public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
    }
}
