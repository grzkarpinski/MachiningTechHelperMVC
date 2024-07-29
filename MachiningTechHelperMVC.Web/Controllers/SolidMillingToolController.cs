using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Domain.Model;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MachiningTechHelperMVC.Web.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "admin, user")]
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
        [Authorize(Roles = "admin, user")]
        public IActionResult AddSolidMillingTool(NewSolidMillingToolVm tool) 
        {
            tool.CreatedAt = DateTime.Now;
            tool.CreatedBy = User.Identity.Name;
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
        [Authorize(Roles = "admin, user")]
        public IActionResult EditSolidMillingTool(int id) 
        {
            var tool = _solidMillingToolService.GetSolidMillingToolForEdit(id);
            ViewBag.ToolTypeList = new SelectList(
               Enum.GetValues(typeof(ToolType))
               .Cast<ToolType>()
               .Select(t => new { Id = (int)t, Name = t.ToString() }),
           "Id", "Name", tool.ToolType);
            if (tool.NewProducer != null) 
            {
                tool.NewProducer = new ProducerVm {CompanyName = tool.NewProducer.CompanyName};
            }
            return View(tool);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult EditSolidMillingTool(NewSolidMillingToolVm tool)
        {
            _solidMillingToolService.UpdateSolidMillingTool(tool);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult Delete(int id)
        {
            _solidMillingToolService.DeleteSolidMillingToolSoft(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeletePermanently(int id)
            {
            _solidMillingToolService.DeleteSolidMillingTool(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult AddParametersRange(int id)
        {
            var model = new SolidMillingToolParametersRangeVm
            {
                SolidMillingToolId = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddParametersRange(SolidMillingToolParametersRangeVm range)
        {
            range.CreatedAt = DateTime.Now;
            range.CreatedBy = User.Identity.Name;
            _solidMillingToolParametersRangeService.AddSolidMillingToolParametersRange(range);
            return RedirectToAction("ViewSolidMillingTool", new { id = range.SolidMillingToolId });
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteParametersRange(int id)
        {
            var range = _solidMillingToolParametersRangeService.GetSolidMillingToolParametersForEdit(id);
            _solidMillingToolParametersRangeService.DeleteSolidMillingToolParametersRange(id);
            return RedirectToAction("ViewSolidMillingTool", new { id = range.SolidMillingToolId });
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddSolidMillingToolCheckedParameters(int id)
        {
            var model = new SolidMillingToolCheckedParametersVm
            {
                SolidMillingToolId = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult AddSolidMillingToolCheckedParameters(SolidMillingToolCheckedParametersVm tool)
        {
            tool.CreatedAt = DateTime.Now;
            tool.CreatedBy = User.Identity.Name;
            _solidMillingToolCheckedParametersService.AddSolidMillingToolCheckedParameters(tool);
            return RedirectToAction("ViewSolidMillingTool", new { id = tool.SolidMillingToolId });
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult DeleteSolidMillingToolCheckedParameters(int id)
        {
            var checkedParameters = _solidMillingToolCheckedParametersService.GetSolidMillingToolCheckedParametersById(id);
            _solidMillingToolCheckedParametersService.DeleteSolidMillingToolCheckedParameters(id);
            return RedirectToAction("ViewSolidMillingTool", new { id = checkedParameters.SolidMillingToolId });
        }
    }
}
