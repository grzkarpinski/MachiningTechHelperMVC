using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class SolidMillingToolController : Controller
    {
        private readonly ISolidMillingToolService _solidMillingToolService;
        private readonly ISolidMillingToolParametersRangeService _solidMillingToolParametersRangeService;
        private readonly ISolidMillingToolCheckedParametersService _solidMillingToolCheckedParametersService;

        public SolidMillingToolController(ISolidMillingToolService solidMillingToolService,
                                                     ISolidMillingToolParametersRangeService solidMillingToolParametersRangeService,
                                                                                              ISolidMillingToolCheckedParametersService solidMillingToolCheckedParametersService)
        {
            _solidMillingToolService = solidMillingToolService;
            _solidMillingToolParametersRangeService = solidMillingToolParametersRangeService;
            _solidMillingToolCheckedParametersService = solidMillingToolCheckedParametersService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _solidMillingToolService.GetAllSolidMillingToolsForList(10, 1, "");
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

            var model = _solidMillingToolService.GetAllSolidMillingToolsForList(pageSize, pageNo, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddSolidMillingTool()
        {
            var model = new NewSolidMillingToolVm
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
        public IActionResult AddSolidMillingTool(NewSolidMillingToolVm tool) 
        {
            var id = _solidMillingToolService.AddSolidMillingTool(tool);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewSolidMillingTool(int id) 
        {
            var toolModel = _solidMillingToolService.GetSolidMillingToolDetails(id);
            return View(toolModel);
        }

        [HttpGet]
        public IActionResult EditSolidMillingTool(int id) 
        {
            var tool = _solidMillingToolService.GetSolidMillingToolForEdit(id);
            ViewBag.ToolTypeList = Enum.GetValues(typeof(ToolType))
                           .Cast<ToolType>()
                           .Select(t => new SelectListItem
                           {
                               Value = ((int)t).ToString(),
                               Text = t.ToString()
                           })
                           .ToList();
            if (tool.NewProducer != null) 
            {
                tool.NewProducer = new ProducerVm {CompanyName = tool.NewProducer.CompanyName};
            }
            return View(tool);
        }

        [HttpPost]
        public IActionResult EditSolidMillingTool(NewSolidMillingToolVm tool)
        {
            _solidMillingToolService.UpdateSolidMillingTool(tool);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _solidMillingToolService.DeleteSolidMillingTool(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddParametersRange(int id)
        {
            var model = new SolidMillingToolParametersRangeVm
            {
                SolidMillingToolId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddParametersRange(SolidMillingToolParametersRangeVm range)
        {
            _solidMillingToolParametersRangeService.AddSolidMillingToolParametersRange(range);
            return RedirectToAction("ViewSolidMillingTool", new { id = range.SolidMillingToolId });
        }

        public IActionResult DeleteParametersRange(int id)
        {
            var range = _solidMillingToolParametersRangeService.GetSolidMillingToolParametersForEdit(id);
            _solidMillingToolParametersRangeService.DeleteSolidMillingToolParametersRange(id);
            return RedirectToAction("ViewSolidMillingTool", new { id = range.SolidMillingToolId });
        }

        [HttpGet]
        public IActionResult AddSolidMillingToolCheckedParameters(int id)
        {
            var model = new SolidMillingToolCheckedParametersVm
            {
                SolidMillingToolId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSolidMillingToolCheckedParameters(SolidMillingToolCheckedParametersVm tool)
        {
            _solidMillingToolCheckedParametersService.AddSolidMillingToolCheckedParameters(tool);
            return RedirectToAction("ViewSolidMillingTool", new { id = tool.SolidMillingToolId });
        }

        public IActionResult DeleteSolidMillingToolCheckedParameters(int id)
        {
            var checkedParameters = _solidMillingToolCheckedParametersService.GetSolidMillingToolCheckedParametersById(id);
            _solidMillingToolCheckedParametersService.DeleteSolidMillingToolCheckedParameters(id);
            return RedirectToAction("ViewSolidMillingTool", new { id = checkedParameters.SolidMillingToolId });
        }
    }
}
