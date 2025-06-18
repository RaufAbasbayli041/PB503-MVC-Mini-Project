using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAConferenceManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
