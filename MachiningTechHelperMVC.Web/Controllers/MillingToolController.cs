﻿using MachiningTechelperMVC.Application.Interfaces;
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

        //milling inserts view: when insert / inserts are linked to the tool, display them in the ViewMillingTool.
        // When specific insert selected go to view with theirs MillingInsertParametersRanges.
        // If insert is not linked to the tool, display "there is no insert linked to this tool" message
        // Add button to Add Milling Insert to the tool

        // 1. contrller for view where user searches for insert to link to the tool (search by insert name)
        // display list of inserts with add button next to each insert
        // link at bottom of the page to create new insert

        // 0. controller to delete insert from the tool
        [HttpPost]
        IActionResult DeleteMillingInsertLink(int millingToolId, int millingInsertId)
        {
            _millingToolMillingInsertService.DeleteMillingToolInsert(millingToolId, millingInsertId);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        [HttpGet]
        IActionResult ViewMillingInserts()
        {
            var model = _millingInsertService.GetAllMillingInserts(10, 1, "");
            return View(model);
        }

        // 1. controller for view where user searches for insert to link to the tool (search by insert name)
        [HttpPost]
        IActionResult ViewMillingInserts(int pageSize, int? pageNo, string searchString)
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
            return View(model);
        }

        // 1.5. controller to link chosen insert to the tool when pressing add button

        [HttpPost]
        IActionResult LinkMillingInsert(int millingToolId, int millingInsertId)
        {
            _millingToolMillingInsertService.AddMillingToolInsert(millingToolId, millingInsertId);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        // 2. controller for view where user can add new insert

        [HttpGet]
        public IActionResult AddMillingInsert(int millingToolId)
        {
            var model = new MillingInsertVm
            {
                MillingToolId = millingToolId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddMillingInsert(MillingInsertVm millingInsert)
        {
            var id = _millingInsertService.AddMillingInsert(millingInsert);
            return RedirectToAction("ViewMillingInsert", new { id });
        }

        // 4. controller for view where user can see insert details and add insert parameters ranges

        IActionResult ViewMillingInsert(int id)
        {
            var model = _millingInsertService.GetMillingInsertById(id);
            return View(model);
        }

        // 5. controller for view where user can add insert parameters ranges

        [HttpGet]
        IActionResult AddMillingInsertParametersRange(int millingInsertId)
        {
            var model = new MillingInsertParametersRangeVm
            {
                MillingInsertId = millingInsertId
            };

            return View(model);
        }

        [HttpPost]
        IActionResult AddMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange)
        {
            _millingInsertParametersRangeService.AddMillingInsertParametersRange(millingInsertParametersRange);
            return RedirectToAction("ViewMillingInsert", new { id = millingInsertParametersRange.MillingInsertId });
        }

        // 6. controller for delete insert parameters range

        IActionResult DeleteMillingInsertParametersRange(int id)
        {
            var millingInsertParametersRange = _millingInsertParametersRangeService.GetMillingInsertParametersRangeById(id);
            _millingInsertParametersRangeService.DeleteMillingInsertParametersRange(id);
            return RedirectToAction("ViewMillingInsert", new { id = millingInsertParametersRange.MillingInsertId });
        }

        // add checked parameters to the milling tool

        [HttpGet]
        IActionResult AddMillingToolCheckedParameters(int millingToolId)
        {
            var model = new MillingToolCheckedParametersVm
            {
                MillingToolId = millingToolId
            };

            return View(model);
        }

        [HttpPost]
        IActionResult AddMillingToolCheckedParameters(MillingToolCheckedParametersVm millingToolCheckedParameters)
        {
            _millingToolCheckedParametersService.AddMillingToolCheckedParameters(millingToolCheckedParameters);
            return RedirectToAction("ViewMillingTool", new { id = millingToolCheckedParameters.MillingToolId });
        }

        // delete checked parameters
        IActionResult DeleteMillingToolCheckedParameters(int id)
        {
            var millingToolCheckedParameters = _millingToolCheckedParametersService.GetMillingToolCheckedParametersById(id);
            _millingToolCheckedParametersService.DeleteMillingToolCheckedParameters(id);
            return RedirectToAction("ViewMillingTool", new { id = millingToolCheckedParameters.MillingToolId });
        }

    }
}