using CAConferenceManagement.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAConferenceManagement.Configurations
{
    public class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasMany(e => e.Invitations)
                .WithOne(l => l.Event)
                .HasForeignKey(l => l.EventId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.EventTypes).WithOne(et => et.Event)
                .HasForeignKey(et => et.EventId)
                .OnDelete(DeleteBehavior.Restrict);


           builder.HasMany(e => e.Organizers).WithOne(o => o.Event)
                .HasForeignKey(o => o.EventId)
                .OnDelete(DeleteBehavior.Restrict);





            builder.HasOne(e => e.Location).WithMany(l => l.Events)
                .HasForeignKey(l => l.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Notifications).WithOne(n => n.Event)
                .HasForeignKey(n => n.EventId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.FeedBacks).WithOne(fb => fb.Event)
                .HasForeignKey(fb => fb.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
