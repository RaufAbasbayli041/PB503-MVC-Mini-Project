using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;

namespace CAConferenceManagement.Service.Interface
{
    public interface ILocationService : IGenericService<LocationDTO,Location>
    {
        Task<IEnumerable<LocationDTO>> GetLocationByEventsIdAsync();

    }
}
