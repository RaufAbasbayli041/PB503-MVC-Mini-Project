using CAConferenceManagement.Models;
using CAConferenceManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CAConferenceManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrganizerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrganizerService _organizerService;
        public OrganizerController(IWebHostEnvironment webHostEnvironment, IOrganizerService organizerService)
        {
            _webHostEnvironment = webHostEnvironment;
            _organizerService = organizerService;
        }
        public async Task<ActionResult> Index()
        {
            var organizer = await _organizerService.GetAllWithUserAsync();
            return View(organizer);
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
			var data = await _organizerService.GetByIdAsync(id);
			if (data == null)
			{
				return NotFound();
			}
			//ViewBag.Merchants = await _db.Merchants.ToListAsync();
			return View(data);
		}

		[HttpPost]
		public async Task<ActionResult> Edit(OrganizerDTO organizerDTO)
		{

			var result = await _organizerService.Update(organizerDTO);
			//ViewBag.Merchants = await _db.Merchants.ToListAsync();
			return RedirectToAction("Index");


		}

		[HttpGet]
		public async Task<IActionResult> Detail(int id)
		{
			var data = await _organizerService.GetByIdAsync(id);
			if (data == null)
			{
				return NotFound();
			}
			return View(data);
		}


		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await _organizerService.DeleteAsync(id);
			if (data == false)
			{
				return NotFound();
			}
			return RedirectToAction("Index");
		}
	}
}
