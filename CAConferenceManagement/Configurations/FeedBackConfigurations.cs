using CAConferenceManagement.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAConferenceManagement.Configurations
{
    public class FeedBackConfigurations : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasOne(f => f.Event)
                .WithMany(e => e.FeedBacks)
                .HasForeignKey(f => f.EventId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.Person)
                .WithMany(p => p.FeedBacks)
               .HasForeignKey(f => f.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
