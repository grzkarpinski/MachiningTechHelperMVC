using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Calculators
{
    public class DrillingCalculationStrategy : CalculationStrategyBase
    {
        public override SimpleCalculatorVm Calculate(SimpleCalculatorVm model)
        {
            model.RevolutionsPerMinute = (int)CalculateRevolutionsPerMinute(model.CuttingSpeed, model.Diameter);
            model.FeedPerMinute = (int)CalculateDrillingFeed(model.FeedPerRevolution, model.RevolutionsPerMinute);
            return model;
        }

        private double CalculateDrillingFeed(double feedPerRevolution, double revolutionsPerMinute)
        {
            return feedPerRevolution * revolutionsPerMinute;
        }
    }
}
