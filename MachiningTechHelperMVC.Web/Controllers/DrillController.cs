using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachiningTechHelperMVC.Web.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "admin, user")]
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
        [Authorize(Roles = "admin, user")]
        public IActionResult AddDrill(NewDrillVm drill)
        {
            drill.CreatedAt = DateTime.Now;
            drill.CreatedBy = User.Identity.Name;
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
        [Authorize(Roles = "admin, user")]
        public IActionResult EditDrill(int id)
        {
            var drill = _drillService.GetDrillForEdit(id);
            ViewBag.ToolTypeList = new SelectList(
               Enum.GetValues(typeof(ToolType))
               .Cast<ToolType>()
               .Select(t => new { Id = (int)t, Name = t.ToString() }),
           "Id", "Name", drill.ToolType);

            if (drill.NewProducer != null)
            {
                drill.NewProducer = new ProducerVm { CompanyName = drill.NewProducer.CompanyName };
            }

            return View(drill);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult EditDrill(NewDrillVm drill)
        {
            _drillService.UpdateDrill(drill);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Delete(int id)
        {
            _drillService.DeleteDrill(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult AddParametersRange(int id)
        {
            var model = new DrillParametersRangeVm
            {
                DrillId = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddParametersRange(DrillParametersRangeVm model)
        {
            model.CreatedAt = DateTime.Now;
            model.CreatedBy = User.Identity.Name;
            _drillParametersRangeService.AddDrillParametersRange(model);
            return RedirectToAction("ViewDrill", new { id = model.DrillId });
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteParametersRange(int id)
        {
            var drillParametersRange = _drillParametersRangeService.GetDrillParametersRangeById(id);
            _drillParametersRangeService.DeleteDrillParametersRange(id);
            return RedirectToAction("ViewDrill", new { id = drillParametersRange.DrillId });
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddDrillCheckedParameters(int id)
        {
            var model = new DrillCheckedParametersVm
            {
                DrillId = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddDrillCheckedParameters(DrillCheckedParametersVm checkedParameters)
        {
            checkedParameters.CreatedAt = DateTime.Now;
            checkedParameters.CreatedBy = User.Identity.Name;
            _drillCheckedParametersService.AddDrillCheckedParameters(checkedParameters);
            return RedirectToAction("ViewDrill", new { id = checkedParameters.DrillId });
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteDrillCheckedParameters(int id)
        {
            var drillCheckedParameters = _drillCheckedParametersService.GetDrillCheckedParametersById(id);
            _drillCheckedParametersService.DeleteDrillCheckedParameters(id);
            return RedirectToAction("ViewDrill", new { id = drillCheckedParameters.DrillId });
        }
    }
}
