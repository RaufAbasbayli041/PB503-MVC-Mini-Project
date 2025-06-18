using CAConferenceManagement.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CAConferenceManagement.Configurations
{
    public class OrganizerConfigurations : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasMany(x => x.Events).WithMany(p => p.Organizers);
        }
    }
}
