using AutoMapper;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;
using CAConferenceManagement.Repository.Interface;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.Service.Implementation
{
    public class EventTypeService : GenericService<EventTypeDTO, EventType>, IEventTypeService
    {
        public EventTypeService(IMapper mapper, IGenericRepository<EventType> repository) : base(mapper, repository)
        {

        }


    }
}
