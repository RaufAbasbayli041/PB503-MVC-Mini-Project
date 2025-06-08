using CAConferenceManagement.Repository.Implementation;
using CAConferenceManagement.Repository.Interface;

namespace CAConferenceManagement.Extensions
{
    public static class CustomRepository
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}
