using System.Diagnostics;
using System.Threading.Tasks;
using CAConferenceManagement.Models;
using CAConferenceManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CAConferenceManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEventService _eventService;


        public HomeController(ILogger<HomeController> logger, IEventService eventService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEventsByOrganizerIdAsync();

            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}