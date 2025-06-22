using CAConferenceManagement.DB;
using CAConferenceManagement.Models;
using CAConferenceManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CAConferenceManagement.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class EventController : Controller
	{

		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IEventService _eventService;
        private readonly ConferenceDB _db;
        public EventController(IWebHostEnvironment webHostEnvironment, IEventService eventService, ConferenceDB db)
        {
            _webHostEnvironment = webHostEnvironment;
            _eventService = eventService;
            _db = db;
        }
        public async Task<ActionResult> Index()
		{
			var events = await _eventService.GetEventsByOrganizerIdAsync();
			return View(events);
		}

		//public async Task<ActionResult> Create()
		//{			
		//	return View();
		//}
		//[HttpPost]
		//public async Task<ActionResult> Create(OrganizerDTO organizerDTO)
		//{

		//	var result = await _organizerService.CreateAsync(organizerDTO);

		//	return RedirectToAction("Index");
		//}

		public async Task<ActionResult> Edit(int id)
		{

            ViewBag.Location = await _db.Locations.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();
            ViewBag.Organizer = await _db.Organizers.ToListAsync();
            var data = await _eventService.GetByIdAsync(id);
			if (data == null)
			{
				return NotFound();
			}
			//ViewBag.Merchants = await _db.Merchants.ToListAsync();
			return View(data);
		}

		[HttpPost]
		public async Task<ActionResult> Edit(EventDTO eventDTO )
		{

            ViewBag.Location = await _db.Locations.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();
            ViewBag.Organizer = await _db.Organizers.ToListAsync();
            var result = await _eventService.Update(eventDTO);
			//ViewBag.Merchants = await _db.Merchants.ToListAsync();
			return RedirectToAction("Index");


		}

		[HttpGet]
		public async Task<IActionResult> Detail(int id)
		{

            ViewBag.Location = await _db.Locations.ToListAsync();
            ViewBag.EventTypes = await _db.EventTypes.ToListAsync();
            ViewBag.Organizer = await _db.Organizers.ToListAsync();
            var data = await _eventService.GetByIdAsync(id);
			if (data == null)
			{
				return NotFound();
			}
			return View(data);
		}


		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _eventService.DeleteAsync(id);
			if (data == false)
			{
				return NotFound();
			}
			return RedirectToAction("Index");
		}
	}

}

