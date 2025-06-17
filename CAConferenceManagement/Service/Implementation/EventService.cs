using AutoMapper;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;
using CAConferenceManagement.Repository.Interface;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.Service.Implementation
{
    public class EventService : GenericService<EventDTO, Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IMapper mapper, IEventRepository eventRepository) : base(mapper, eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EventDTO>> GetEventsByOrganizerIdAsync()
        {
            var events = await _eventRepository.GetEventsByOrganizersIdAsync();
            if (events == null)
            {
                return null;
            }
            var eventDtos = _mapper.Map<IEnumerable<EventDTO>>(events);
            return eventDtos;



        }

    }
    
    
}
