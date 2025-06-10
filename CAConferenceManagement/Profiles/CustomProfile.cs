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
            CreateMap<Organizer, OrganizerDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Invitation, InvitationDTO>().ReverseMap();
            CreateMap<EventType, EventTypeDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<FeedBack, FeedBackDTO>().ReverseMap();
            CreateMap<EventDTO,Event>().ReverseMap();
        }
    }
}
