namespace CAConferenceManagement.Models
{
    public class ParticipationDTO
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int InvitationId { get; set; }
       
        public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
        // Additional properties can be added as needed
    }
}
