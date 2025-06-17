using AutoMapper;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Models;
using CAConferenceManagement.Repository.Implementation;
using CAConferenceManagement.Repository.Interface;
using CAConferenceManagement.Service.Implementation;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.CustomProfile
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<OrganizerDTO, Organizer>().ReverseMap();
            CreateMap<Event, EventDTO>()
     .ForMember(dest => dest.Organizers, opt => opt.MapFrom(src => src.Organizers))
     .ForMember(dest => dest.EventTypes, opt => opt.MapFrom(src => src.EventTypes))
        .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
     .ReverseMap();
            CreateMap<Invitation, InvitationDTO>().ReverseMap();
            CreateMap<EventType, EventTypeDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<FeedBack, FeedBackDTO>().ReverseMap();
          
        }
    }
}
