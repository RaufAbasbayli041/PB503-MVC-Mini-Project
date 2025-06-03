using CAConferenceManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.DB
{
    public class ConferenceDB : DbContext
    {
        public ConferenceDB(DbContextOptions<ConferenceDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
            {
               entityType.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);

        }
        // DbSet properties for your entities

        public DbSet<Event> Events { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }
    
    
}
