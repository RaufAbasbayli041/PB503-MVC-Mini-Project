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
            return await _conferenceDB.Events.Include(e => e.Organizers)
                 .Where(e => e.Organizers.Any()).AsNoTracking()
                 .ToListAsync();

        }


    }
}
