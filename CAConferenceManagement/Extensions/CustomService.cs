using CAConferenceManagement.Service.Implementation;
using CAConferenceManagement.Service.Interface;

namespace CAConferenceManagement.Extensions
{
    public static class CustomService
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IEventTypeService, EventTypeService>();


        }
    }
}
