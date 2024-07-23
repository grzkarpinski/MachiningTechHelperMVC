using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Calculators
{
    public class SimpleCalculatorContext
    {
        public readonly ICalculationStrategy _strategy;

        public SimpleCalculatorContext(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public SimpleCalculatorVm Calculate(SimpleCalculatorVm model)
        {
            return _strategy.Calculate(model);
        }
    }
}
