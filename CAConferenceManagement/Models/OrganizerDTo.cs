using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Models
{
    public class OrganizerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
         public User User { get; set; }
	}
}
