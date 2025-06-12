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

        public async Task<IEnumerable<Event>> GetEventsByOrganizerIdAsync()
        {
            return await _conferenceDB.Events.Include(x => x.Organizer)
                .Where(y => y.OrganizerId != null && y.IsDeleted == false)
                .Include(z=>z.Location)
                .Where(x => x.LocationId != null && x.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();
        }

       
    }
}
