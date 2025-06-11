using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;

namespace CAConferenceManagement.Service.Interface
{
    public interface IEventService : IGenericService<EventDTO, Event>
    {
        Task<IEnumerable<EventDTO>> GetEventsByOrganizerIdAsync();
    }
}
