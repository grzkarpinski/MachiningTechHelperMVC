using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class DrillController : Controller // pseudocode to impelement the drill controller
    {
        private readonly IDrillService _drillService;
        public DrillController(IDrillService drillService) 
        {
            _drillService = drillService;
        }
        public IActionResult Index()
        {
            var model = _drillService.GetAllDrillsForList();
            return View(model);
        }

        //[HttpGet]
        //public IActionResult AddDrill()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddDrill(DrillModel drill)
        //{
        //    var id = _drillService.AddDrill(drill);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddNewDrillCheckedParameters(int Drillid)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddNewDrillCheckedParameters(DrillCheckedParametersModel model) 
        //{
        //    return View();
        //}

        public IActionResult ViewDrill(int id)
        {
            var drillModel = _drillService.GetDrillDetails(id);
            return View(drillModel);
        }
    }
}
