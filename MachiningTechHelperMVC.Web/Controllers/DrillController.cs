using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Model;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class DrillController : Controller
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
			var model = new NewDrillVm
			{
				ToolTypes = Enum.GetValues(typeof(ToolType))
								.Cast<ToolType>()
								.Select(t => new SelectListItem
								{
									Value = ((int)t).ToString(),
									Text = t.ToString()
								})
			};

			return View(model);
		}

		[HttpPost]
        public IActionResult AddDrill(NewDrillVm drill)
        {
            var id = _drillService.AddDrill(drill);
            return RedirectToAction("Index");
        }

		public IActionResult ViewDrill(int id)
        {
            var drillModel = _drillService.GetDrillDetails(id);
            return View(drillModel);
        }

        [HttpGet]
        public IActionResult EditDrill(int id)
        {
            var drill = _drillService.GetDrillForEdit(id);
            ViewBag.ToolTypeList = Enum.GetValues(typeof(ToolType))
                           .Cast<ToolType>()
                           .Select(t => new SelectListItem
                           {
                               Value = ((int)t).ToString(),
                               Text = t.ToString()
                           })
                           .ToList();

            return View(drill);
        }

        [HttpPost]
        public IActionResult EditDrill(NewDrillVm drill)
        {
            _drillService.UpdateDrill(drill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _drillService.DeleteDrill(id);
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
    }
}
