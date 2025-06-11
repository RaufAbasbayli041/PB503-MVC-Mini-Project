using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Repository.Implementation
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(ConferenceDB context) : base(context)
        {
        }

        public async Task<IEnumerable<Location>> GetLocationsByEventIdAsync()
        {
            return await _conferenceDB.Locations
                .Include(location => location.Event)
                .Where(location => location.EventId != null && !location.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }
    }
    
}
