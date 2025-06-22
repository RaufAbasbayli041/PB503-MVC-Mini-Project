using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Repository.Implementation
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(ConferenceDB conferenceDB) : base(conferenceDB)
        {
        }

        public async Task<IEnumerable<Event>> GetEventsByOrganizersIdAsync()
        {
            var a = await _conferenceDB.Events
                .Include(e => e.Organizers)
                .Include(e => e.EventTypes)
                .Include(e => e.Location)              
                .Where(e => e.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();
            return a;

            //return await _conferenceDB.Events.Include(e => e.Organizers)
            //     .Where(e => e.Organizers.Any()).AsNoTracking()
            //     .ToListAsync();

        }


    }
}
