using CAConferenceManagement.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Entity
{
    [EntityTypeConfiguration(typeof(OrganizerConfigurations))]
    public class Organizer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
