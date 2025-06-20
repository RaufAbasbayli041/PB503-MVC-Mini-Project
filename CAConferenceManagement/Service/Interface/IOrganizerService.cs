using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;

namespace CAConferenceManagement.Service.Interface
{
    public interface IOrganizerService :IGenericService<OrganizerDTO, Organizer> 
    {
		Task<IEnumerable<OrganizerDTO>> GetAllWithUserAsync();
	}
}
