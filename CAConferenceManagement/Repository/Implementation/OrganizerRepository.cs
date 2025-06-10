using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;

namespace CAConferenceManagement.Repository.Implementation
{
    public class OrganizerRepository : GenericRepository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(ConferenceDB conferenceDB) : base(conferenceDB)
        {
        }
    }
}
