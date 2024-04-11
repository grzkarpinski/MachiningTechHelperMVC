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

			if (model.IsMilling == true)
			{
				model.RevolutionsPerMinute = (int)CalculateRevitonsPerMinute(model.CuttingSpeed, model.Diameter);
				model.FeedPerMinute = (int)CalculateMillingFeed(model.FeedPerTooth, model.Teeth, model.RevolutionsPerMinute);
			}
			else
			{
				model.RevolutionsPerMinute = (int)CalculateRevitonsPerMinute(model.CuttingSpeed, model.Diameter);
				model.FeedPerMinute = (int)CalculateDrillingFeed(model.FeedPerRevolution, model.RevolutionsPerMinute);
			}

			return model;
		}
		public double CalculateRevitonsPerMinute(double cuttingSpeed, double diameter)
        {
            return (1000 * cuttingSpeed) / (Math.PI * diameter);
        }

        public double CalculateMillingFeed(double feedPerTooth, int teeth, double revolutionsPerMinute)
        {
            return feedPerTooth * teeth * revolutionsPerMinute;
        }

        public double CalculateDrillingFeed(double feedPerRevolution, double revolutionsPerMinute)
        {
            return feedPerRevolution * revolutionsPerMinute;
        }
    }
}
