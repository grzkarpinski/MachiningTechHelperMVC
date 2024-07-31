using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class CostEstimationController : Controller
    {
        private readonly ICostEstimationLogic _costEstimationLogic;
        private readonly ILogger<CostEstimationController> _logger;

        public CostEstimationController(ICostEstimationLogic costEstimationLogic, ILogger<CostEstimationController> logger)
        {
            _costEstimationLogic = costEstimationLogic;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("costestimation/index");
            var model = new CostEstimationVm();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CostEstimationVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var result = _costEstimationLogic.CalculateCosts(model);
            return View("Result", result);
        }

        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }
    }
}
