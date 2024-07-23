using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Calculators
{
    public class MillingCalculationStrategy: CalculationStrategyBase
    {
        public override SimpleCalculatorVm Calculate(SimpleCalculatorVm model)
        {
            model.RevolutionsPerMinute = (int)CalculateRevolutionsPerMinute(model.CuttingSpeed, model.Diameter);
            model.FeedPerMinute = (int)CalculateMillingFeed(model.FeedPerTooth, model.Teeth, model.RevolutionsPerMinute);
            return model;
        }
        private double CalculateMillingFeed(double feedPerTooth, int teeth, double revolutionsPerMinute)
        {
            return feedPerTooth * teeth * revolutionsPerMinute;
        }
    }
}
