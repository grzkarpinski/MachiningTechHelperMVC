using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class SimpleCalculatorController : Controller
    {
        // calculator to be implemented
        // calculate revisions per second
        // calculate feed for milling or drilling
        public IActionResult Index()
        {
            return View();
        }
    }
}
