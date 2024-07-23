using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Calculators
{
    public abstract class CalculationStrategyBase : ICalculationStrategy
    {
        public abstract SimpleCalculatorVm Calculate(SimpleCalculatorVm model);

        protected double CalculateRevolutionsPerMinute(double cuttingSpeed, double diameter)
        {
            return (1000 * cuttingSpeed) / (Math.PI * diameter);
        }
    }
}
