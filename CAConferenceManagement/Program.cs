using CAConferenceManagement.DB;
using CAConferenceManagement.Entity;
using CAConferenceManagement.Extensions;
using CAConferenceManagement.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CAConferenceManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ConferenceDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Registering the custom repository and service extensions

            builder.Services.AddIdentity<User, IdentityRole>(options =>
              {

                  options.SignIn.RequireConfirmedAccount = false;
                  options.User.RequireUniqueEmail = true;
                  options.Password.RequiredLength = 8;
                  options.Password.RequireDigit = true;
                  options.Password.RequireLowercase = false;
                  options.User.RequireUniqueEmail = true;
                  options.Password.RequireUppercase = false;
                  options.Password.RequireNonAlphanumeric = false;
              }).AddEntityFrameworkStores<ConferenceDB>()
                            .AddDefaultTokenProviders();






            builder.Services.AddRepository();
            builder.Services.AddService();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            // Initialize the database and roles
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Ensure the database is created
                    var context = services.GetRequiredService<ConferenceDB>();
                    await context.Database.MigrateAsync();
                    // Set up roles
                    await DBHelper.SetRoles(services);
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log them)
                    Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
                }

            }



            app.Run();
        }
    }
}
