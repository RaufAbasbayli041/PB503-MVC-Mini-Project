using AutoMapper;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;
using CAConferenceManagement.Repository.Interface;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.Service.Implementation
{
    public class LocationService : GenericService<LocationDTO, Location>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper) : base(mapper, locationRepository)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<LocationDTO>> GetLocationsByEventIdAsync()
        {
            var locations = await _locationRepository.GetLocationsByEventIdAsync();
            if (locations == null)
            {
                return null;
            }
            var locationDtos = _mapper.Map<IEnumerable<LocationDTO>>(locations);
            return locationDtos;


        }
    }
}
