using CAConferenceManagement.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Entity
{
    [EntityTypeConfiguration(typeof(FeedBackConfigurations))]
    public class FeedBack : BaseEntity
    {
        public string Comment { get; set; }
        public int Rating { get; set; } // Assuming rating is an integer value
        public int EventId { get; set; }
        public Event Event { get; set; }


        public string UserId { get; set; }
        public User USer { get; set; }
    }
}
