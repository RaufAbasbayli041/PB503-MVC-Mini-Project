using CAConferenceManagement.Entity;

namespace CAConferenceManagement.Repository.Interface
{
	public interface IOrganizerRepository : IGenericRepository<Organizer>
	{
		Task<IEnumerable<Organizer>> GetAllWithUserAsync();
	}
}
