using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
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

        [HttpGet]
        public IActionResult Index()
        {
            var model = _drillService.GetAllDrillsForList(10, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _drillService.GetAllDrillsForList(pageSize, pageNo, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddDrill()
        {
            return View(new NewDrillVm());
        }

        [HttpPost]
        public IActionResult AddDrill(NewDrillVm drill)
        {
            var id = _drillService.AddDrill(drill);
            return RedirectToAction("Index");
        }

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
