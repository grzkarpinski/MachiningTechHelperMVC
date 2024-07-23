using MachiningTechelperMVC.Application.Calculators;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Calculators
{
    public class SimpleCalculatorLogic : ISimpleCalculatorLogic
    {
		public SimpleCalculatorVm Calculate(SimpleCalculatorVm model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			ICalculationStrategy strategy;
			if (model.IsMilling)
			{
				strategy = new MillingCalculationStrategy();
			}
			else
            {
                strategy = new DrillingCalculationStrategy();
            }

			var context = new SimpleCalculatorContext(strategy);
			return context.Calculate(model);
		}
    }
}
