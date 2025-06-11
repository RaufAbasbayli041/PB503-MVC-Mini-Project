using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Repository.Interface
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByOrganizerIdAsync();
       


    }
}
