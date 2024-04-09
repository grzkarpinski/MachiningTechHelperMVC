using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
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
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(SimpleCalculatorVm model)
        {
            if (ModelState.IsValid)
            {
                if ((bool)model.IsMilling)
                {
                    model.RevolutionsPerMinute = (int)_calculatorLogic.CalculateRevitonsPerMinute(model.CuttingSpeed, model.Diameter);
                    model.FeedPerMinute = _calculatorLogic.CalculateMillingFeed(model.FeedPerTooth, model.Teeth, model.RevolutionsPerMinute);
                }
                else if ((bool)model.IsDrilling)
                {
                    model.RevolutionsPerMinute = (int)_calculatorLogic.CalculateRevitonsPerMinute(model.CuttingSpeed, model.Diameter);
                    model.FeedPerMinute = _calculatorLogic.CalculateDrillingFeed(model.FeedPerRevolution, model.RevolutionsPerMinute);
                }
                return View("Index", model);
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}
