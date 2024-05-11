using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Domain.Model;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class MillingToolController : Controller
    {
        private readonly IMillingToolService _millingToolService;
        private readonly IMillingInsertService _millingInsertService;
        private readonly IMillingInsertParametersRangeService _millingInsertParametersRangeService;
        private readonly IMillingToolCheckedParametersService _millingToolCheckedParametersService;
        private readonly IMillingToolMillingInsertService _millingToolMillingInsertService;

        public MillingToolController(IMillingToolService millingToolService,
                                     IMillingInsertService millingInsertService,
                                     IMillingInsertParametersRangeService millingInsertParametersRangeService,
                                     IMillingToolCheckedParametersService millingToolCheckedParametersService,
                                     IMillingToolMillingInsertService millingToolMillingInsertService)
        {
            _millingToolService = millingToolService;
            _millingInsertService = millingInsertService;
            _millingInsertParametersRangeService = millingInsertParametersRangeService;
            _millingToolCheckedParametersService = millingToolCheckedParametersService;
            _millingToolMillingInsertService = millingToolMillingInsertService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var model = _millingToolService.GetAllMillingToolsForList(10, 1, "");
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

            var model = _millingToolService.GetAllMillingToolsForList(pageSize, pageNo, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddMillingTool()
        {
            var model = new NewMillingToolVm
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
        public IActionResult AddMillingTool(NewMillingToolVm millingTool)
        {
            var id = _millingToolService.AddMillingTool(millingTool);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewMillingTool(int id)
        {
            var millingToolModel = _millingToolService.GetMillingToolDetails(id);
            return View(millingToolModel);
        }

        [HttpGet]
        public IActionResult EditMillingTool(int id)
        {
            var tool = _millingToolService.GetMillingToolForEdit(id);
            ViewBag.ToolTypeList = Enum.GetValues(typeof(ToolType))
                           .Cast<ToolType>()
                           .Select(t => new SelectListItem
                           {
                               Value = ((int)t).ToString(),
                               Text = t.ToString(),
                               Selected = t.ToString() == tool.ToolType // BUG: selected iten should be tool.toolType
                           })
                           .ToList();
            if (tool.NewProducer != null)
            {
                tool.NewProducer = new ProducerVm { CompanyName = tool.NewProducer.CompanyName };
            }

            return View(tool);
        }

        [HttpPost]
        public IActionResult EditMillingTool(NewMillingToolVm millingTool)
        {
            _millingToolService.UpdateMillingTool(millingTool);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMillingTool(int id)
        {
            _millingToolService.DeleteMillingTool(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMillingInsertLink(int millingToolId, int millingInsertId)
        {
            _millingToolMillingInsertService.DeleteMillingToolInsert(millingToolId, millingInsertId);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        [HttpGet]
        public IActionResult ViewMillingInserts(int millingToolId)
        {
            var model = _millingInsertService.GetAllMillingInserts(10, 1, "");
            model.MillingToolId = millingToolId;
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewMillingInserts(int millingToolId, int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _millingInsertService.GetAllMillingInserts(pageSize, pageNo, searchString);
            model.MillingToolId = millingToolId;
            return View(model);
        }

         public IActionResult LinkMillingInsert(int millingToolId, int millingInsertId)
        {
            _millingToolMillingInsertService.AddMillingToolInsert(millingToolId, millingInsertId);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        public IActionResult DeleteLinkMillingInsert(int millingToolId, int millingInsertId)
        {
            _millingToolMillingInsertService.DeleteMillingToolInsert(millingToolId, millingInsertId);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        [HttpGet]
        public IActionResult AddMillingInsert()
        {
            var model = new MillingInsertVm();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMillingInsert(MillingInsertVm millingInsert)
        {
            var id = _millingInsertService.AddMillingInsert(millingInsert);
            return RedirectToAction("ViewMillingInserts");
        }

        public IActionResult ViewMillingInsert(int id)
        {
            var model = _millingInsertService.GetMillingInsertById(id);
            return View(model);
        }

        public IActionResult DeleteMillingInsert(int id)
        {
            _millingInsertService.DeleteMillingInsert(id);
            return RedirectToAction("ViewMillingInserts");
        }

        [HttpGet]
        public IActionResult AddMillingInsertParametersRange(int insertId)
        {
            var model = new MillingInsertParametersRangeVm
            {
                MillingInsertId = insertId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange)
        {
            _millingInsertParametersRangeService.AddMillingInsertParametersRange(millingInsertParametersRange);
            return RedirectToAction("ViewMillingInsert", new { id = millingInsertParametersRange.MillingInsertId });
        }

        public IActionResult DeleteMillingInsertParametersRange(int id)
        {
            var millingInsertParametersRange = _millingInsertParametersRangeService.GetMillingInsertParametersRangeById(id);
            _millingInsertParametersRangeService.DeleteMillingInsertParametersRange(id);
            return RedirectToAction("ViewMillingInsert", new { id = millingInsertParametersRange.MillingInsertId });
        }

        [HttpGet]
        public IActionResult AddMillingToolCheckedParameters(int id)
        {
            var model = new MillingToolCheckedParametersVm
            {
                MillingToolId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMillingToolCheckedParameters(MillingToolCheckedParametersVm tool)
        {
            _millingToolCheckedParametersService.AddMillingToolCheckedParameters(tool);
            return RedirectToAction("ViewMillingTool", new { id = tool.MillingToolId });
        }

        public IActionResult DeleteMillingToolCheckedParameters(int id)
        {
            var millingToolCheckedParameters = _millingToolCheckedParametersService.GetMillingToolCheckedParametersById(id);
            _millingToolCheckedParametersService.DeleteMillingToolCheckedParameters(id);
            return RedirectToAction("ViewMillingTool", new { id = millingToolCheckedParameters.MillingToolId });
        }

    }
}