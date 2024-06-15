using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperApi.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class SimpleCalculatorController : ControllerBase
    {
        private readonly ISimpleCalculatorLogic _calculatorLogic;

        public SimpleCalculatorController(ISimpleCalculatorLogic SimpleCalculatorLogic)
        {
            _calculatorLogic = SimpleCalculatorLogic;
        }

        [HttpGet]
        public ActionResult<SimpleCalculatorVm> Index()
        {
			var model = new SimpleCalculatorVm();
            return Ok(model);
        }

		[HttpPost]
		public ActionResult<SimpleCalculatorVm> Index([FromBody] SimpleCalculatorVm model)
		{
            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
			}

			var result = _calculatorLogic.Calculate(model);
			return Ok(result);
		}
	}
}
