using CAConferenceManagement.DB;
using CAConferenceManagement.Models;
using CAConferenceManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CAConferenceManagement.Areas.Organizer.Controllers
{
    [Area("Organizer")]
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEventService _eventService;
        private readonly ConferenceDB _db;

        public EventController(IEventService eventService, IWebHostEnvironment webHostEnvironment, ConferenceDB db)
        {
            _eventService = eventService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {

           var events = await _eventService.GetEventsByOrganizerIdAsync();
            return View(events);
        }


        public async Task<ActionResult> Details(int id)
        {
            ViewBag.Location = await _db.Locations.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();
            var data = await _eventService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
            
        }
               
        public async Task<ActionResult> Create()
        {
         ViewBag.Organizer = await _db.Organizers.ToListAsync();
            ViewBag.Location = await _db.Locations.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EventDTO eventDTO)
        {
            ViewBag.Organizer = await _db.Organizers.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();
            ViewBag.Location = await _db.Locations.ToListAsync();

            var data = await _eventService.CreateAsync(eventDTO);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));

        }


    }
}
