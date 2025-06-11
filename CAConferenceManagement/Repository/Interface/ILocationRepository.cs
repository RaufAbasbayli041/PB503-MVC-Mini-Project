using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Repository.Interface
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
      
        Task<IEnumerable<Location>> GetLocationsByEventIdAsync();
      
    }
}
