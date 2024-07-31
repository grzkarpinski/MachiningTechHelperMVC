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
		private readonly ILogger<SimpleCalculatorController> _logger;

        public SimpleCalculatorController(ISimpleCalculatorLogic SimpleCalculatorLogic, ILogger<SimpleCalculatorController> logger)
        {
            _calculatorLogic = SimpleCalculatorLogic;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
			_logger.LogInformation("simplecalculator/index");
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
