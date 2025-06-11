using CAConferenceManagement.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.DB
{
    public class ConferenceDB : IdentityDbContext<User>
    {
        public ConferenceDB(DbContextOptions<ConferenceDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                entityType.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            // Seed initial data for EventTypes

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Tech Conference 2023", Description = "A conference about the latest in technology.", EventDate = new DateTime(2023, 10, 15), OrganizerId = 2, },
                new Event { Id = 2, Title = "AI Workshop", Description = "A workshop on artificial intelligence.", EventDate = new DateTime(2023, 11, 20), OrganizerId = 1 }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Convention Center", Address = "123 Main St, Cityville", EventId = 2, Capacity = 200 },
                new Location { Id = 2, Name = "Tech Hub", Address = "456 Tech Rd, Innovatown", EventId = 1, Capacity = 15 }
            );


            modelBuilder.Entity<EventType>().HasData(
                new EventType { Id = 1, Name = "Conference", EventId = 1 },
                new EventType { Id = 2, Name = "Workshop", EventId = 2 }

            );

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer { Id = 1, Name = "organizer1", Surname = "organizer1", Email = "organizer1@gmail.com" },
                new Organizer
                {
                    Id = 2,
                    Name = "organizer2",
                    Surname = "organizer2",
                    Email = "organizer2@gmail.com",
                }
            );

        }


        // DbSet properties for your entities

        public DbSet<Event> Events { get; set; }
       
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }


}
