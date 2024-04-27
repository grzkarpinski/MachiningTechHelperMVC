﻿using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
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

        public MillingToolController(IMillingToolService millingToolService,
                                     IMillingInsertService millingInsertService,
                                     IMillingInsertParametersRangeService millingInsertParametersRangeService,
                                     IMillingToolCheckedParametersService millingToolCheckedParametersService)
        {
            _millingToolService = millingToolService;
            _millingInsertService = millingInsertService;
            _millingInsertParametersRangeService = millingInsertParametersRangeService;
            _millingToolCheckedParametersService = millingToolCheckedParametersService;
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
                               Text = t.ToString()
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
        public IActionResult AddMillingInsert(int millingToolId, MillingInsertVm insertVm)
        {
            insertVm.MillingToolId = millingToolId;
            _millingInsertService.AddMillingInsert(insertVm);
            return RedirectToAction("ViewMillingTool", new { id = millingToolId });
        }

        // view milling insert

        // add checked parameters

        // delete checked parameters

    }
}