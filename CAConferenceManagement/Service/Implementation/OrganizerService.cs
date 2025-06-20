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
		private readonly IOrganizerRepository _organizerRepository;
		private readonly IMapper _mapper;

		public OrganizerService(IOrganizerRepository organizerRepository, IMapper mapper) : base(mapper, organizerRepository)
		{
			_organizerRepository = organizerRepository;
			_mapper = mapper;
		}
			
		

		public async Task<IEnumerable<OrganizerDTO>> GetAllWithUserAsync()
		{
			var datas = await _organizerRepository.GetAllWithUserAsync();
			if (datas == null)
			{
				return null;
			}
			var organizerDtos = _mapper.Map<IEnumerable<OrganizerDTO>>(datas);
			return organizerDtos;
		}
	}

}
