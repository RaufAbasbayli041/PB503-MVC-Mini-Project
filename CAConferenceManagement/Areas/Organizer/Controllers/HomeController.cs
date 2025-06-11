using CAConferenceManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CAConferenceManagement.Areas.Organizer.Controllers
{
    [Area("Organizer")]
    public class HomeController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
       

        public HomeController(IWebHostEnvironment webHostEnvironment, IOrganizerService organizerService)
        {
            _webHostEnvironment = webHostEnvironment;
            _organizerService = organizerService;
        }

        public async Task<ActionResult> Index()
        {
            var organizer = await _organizerService.GetAllAsync();
            return View(organizer);
        }

    }
}
