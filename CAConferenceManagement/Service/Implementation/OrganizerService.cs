using AutoMapper;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;
using CAConferenceManagement.Repository.Implementation;
using CAConferenceManagement.Repository.Interface;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.Service.Implementation
{
    public class OrganizerService : GenericService<OrganizerDTO, Organizer>, IOrganizerService
    {
        public OrganizerService(IMapper mapper, IGenericRepository<Organizer> repository) : base(mapper, repository)
        {

        }
    }

}
