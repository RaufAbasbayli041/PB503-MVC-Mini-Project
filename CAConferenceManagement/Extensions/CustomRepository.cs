using CAConferenceManagement.Repository.Implementation;
using CAConferenceManagement.Repository.Interface;
using OrganizerRepository = CAConferenceManagement.Repository.Implementation.OrganizerRepository;

namespace CAConferenceManagement.Extensions
{
    public static class CustomRepository
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IEventRepository, EventRepository>();


        }
    }
}
