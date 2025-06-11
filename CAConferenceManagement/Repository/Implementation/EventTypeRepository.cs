using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;

namespace CAConferenceManagement.Repository.Implementation
{
    public class EventTypeRepository : GenericRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(ConferenceDB conferenceDB) : base(conferenceDB)
        {
        }
    }
}
