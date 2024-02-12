using MachiningTechHelperMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class DrillController : Controller // WIP
    {
        public IActionResult Index()
        {
            var model = DrillService.GetAllDrillsForList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddDrill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDrill(DrillModel drill)
        {
            var id = DrillService.AddDrill(drill);
            return View();
        }

        public IActionResult ViewDrill(int id)
        {
            var drillModel = DrillService.GetDrillById(id);
            return View(drillModel);
        }
    }
}
