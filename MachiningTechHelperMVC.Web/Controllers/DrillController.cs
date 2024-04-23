using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class DrillController : Controller
    {
        private readonly IDrillService _drillService;
        private readonly IDrillParametersRangeService _drillParametersRangeService;
        private readonly IDrillCheckedParametersService _drillCheckedParametersService;
        public DrillController(IDrillService drillService,
                               IDrillParametersRangeService drillParametersRangeService,
                               IDrillCheckedParametersService drillCheckedParametersService)
        {
            _drillService = drillService;
            _drillParametersRangeService = drillParametersRangeService;
            _drillCheckedParametersService = drillCheckedParametersService;
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
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
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

        [HttpGet]
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
            if (drill.NewProducer != null)
            {
                drill.NewProducer = new ProducerVm { CompanyName = drill.NewProducer.CompanyName };
            }

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

        public IActionResult AddParametersRange(int id)
        {
            var model = new DrillParametersRangeVm
            {
                DrillId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddParametersRange(DrillParametersRangeVm model)
        {
            _drillParametersRangeService.AddDrillParametersRange(model);
            return RedirectToAction("ViewDrill", new { id = model.DrillId });
        }

        public IActionResult DeleteParametersRange(int id)
        {
            var drillParametersRange = _drillParametersRangeService.GetDrillParametersRangeById(id);
            _drillParametersRangeService.DeleteDrillParametersRange(id);
            return RedirectToAction("ViewDrill", new { id = drillParametersRange.DrillId });
        }

        [HttpGet]
        public IActionResult AddDrillCheckedParameters(int id)
        {
            var model = new DrillCheckedParametersVm
            {
                DrillId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDrillCheckedParameters(DrillCheckedParametersVm checkedParameters)
        {
            _drillCheckedParametersService.AddDrillCheckedParameters(checkedParameters);
            return RedirectToAction("ViewDrill", new { id = checkedParameters.DrillId });
        }

        public IActionResult DeleteDrillCheckedParameters(int id)
        {
            var drillCheckedParameters = _drillCheckedParametersService.GetDrillCheckedParametersById(id);
            _drillCheckedParametersService.DeleteDrillCheckedParameters(id);
            return RedirectToAction("ViewDrill", new { id = drillCheckedParameters.DrillId });
        }
    }
}
