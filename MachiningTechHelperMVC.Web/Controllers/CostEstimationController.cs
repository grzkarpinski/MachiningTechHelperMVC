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

        public CostEstimationController(ICostEstimationLogic costEstimationLogic)
        {
            _costEstimationLogic = costEstimationLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
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
