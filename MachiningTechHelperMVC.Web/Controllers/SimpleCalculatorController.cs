using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
	[AllowAnonymous]
	public class SimpleCalculatorController : Controller
    {
        private readonly ISimpleCalculatorLogic _calculatorLogic;

        public SimpleCalculatorController(ISimpleCalculatorLogic SimpleCalculatorLogic)
        {
            _calculatorLogic = SimpleCalculatorLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
			var model = new SimpleCalculatorVm();
            return View(model);
        }

		[HttpPost]
		public IActionResult Index(SimpleCalculatorVm model)
		{
            if (!ModelState.IsValid)
            {
				return View("Index", model);
			}

			var result = _calculatorLogic.Calculate(model);
			return View("Result", result);
		}

		[HttpGet]
		public IActionResult Result()
		{
			return View();
		}
	}
}
