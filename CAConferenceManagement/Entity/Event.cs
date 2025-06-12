using CAConferenceManagement.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Entity
{
    [EntityTypeConfiguration(typeof(EventConfigurations))]
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        public ICollection<EventType> EventTypes { get; set; } = new List<EventType>();
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    }
}
