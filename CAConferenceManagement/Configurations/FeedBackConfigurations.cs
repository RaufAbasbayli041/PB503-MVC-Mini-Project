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
            builder.HasOne(f => f.USer)
                .WithMany(p => p.FeedBacks)
               .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
