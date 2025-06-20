using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Repository.Implementation
{
	public class OrganizerRepository : GenericRepository<Organizer>, IOrganizerRepository
	{
		public OrganizerRepository(ConferenceDB conferenceDB) : base(conferenceDB)
		{
		}

		public async Task<IEnumerable<Organizer>> GetAllWithUserAsync()
		{
			var data = await _conferenceDB.Organizers
				.Include(o => o.User)
				.Where(o => !o.IsDeleted)
				.AsNoTracking()
			.ToListAsync();
			return data;
		}
	}
}
