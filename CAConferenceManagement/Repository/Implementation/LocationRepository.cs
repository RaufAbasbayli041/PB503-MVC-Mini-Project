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

        public async Task<IEnumerable<Location>> GetLocationByEventsIdAsync()
        {
            return await _conferenceDB.Locations
                .Include(location => location.Events)
                .Where(location => location.Events.Any() && !location.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }
    }
    
}
